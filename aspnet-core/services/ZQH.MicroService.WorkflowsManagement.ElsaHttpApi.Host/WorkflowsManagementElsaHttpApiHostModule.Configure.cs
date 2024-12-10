using Microsoft.OpenApi.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Json.SystemTextJson;
using Volo.Abp.Json;
using Volo.Abp.Threading;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Volo.Abp.Http.Client;
using ZQH.Abp.Wrapper;
using Microsoft.IdentityModel.Logging;
using ZQH.Abp.Serilog.Enrichers.Application;
using ZQH.Abp.Serilog.Enrichers.UniqueId;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Localization;
using ZQH.Abp.Localization.CultureMap;
using Volo.Abp.VirtualFileSystem;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using Volo.Abp.Caching;
using ZQH.Abp.Onboarding.Localization;
using Microsoft.AspNetCore.Builder.Extensions;
using DotNetCore.CAP;
using Volo.Abp.Quartz;
using Quartz;
using ZQH.MicroService.Workflows.ElsaHttpApi.Host;
using ZQH.Abp.ExceptionHandling;
using Volo.Abp;
using Medallion.Threading;
using Medallion.Threading.Redis;
using ZQH.MicroService.Workflows.ElsaHttpApi.Host.ElsaHttpApi.Host;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Timing;
using Volo.Abp.Auditing;
using Volo.Abp.Security.Claims;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using Volo.Abp.GlobalFeatures;

//namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host.ElsaHttpApi.Host;
namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host;
public partial class WorkflowsManagementElsaHttpApiHostModule
{
    public static string ApplicationName { get; set; } = "WorkflowHttpApiHost";
    protected const string DefaultCorsPolicyName = "Default";
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    private void PreConfigureFeature()
    {
        OneTimeRunner.Run(() =>
        {
            GlobalFeatureManager.Instance.Modules.Editions().EnableAll();
        });
    }
    private void ConfigureDbContext()
    {
        // 配置Ef
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
        });
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
        // Swagger
        services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Workflow API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                            },
                            new string[] { }
                        }
                });
                options.OperationFilter<TenantHeaderParamter>();
            });
    }

    private void ConfigureJsonSerializer(IConfiguration configuration)
    {
        // 统一时间日期格式
        Configure<AbpJsonOptions>(options =>
        {
            var jsonConfiguration = configuration.GetSection("Json");
            if (jsonConfiguration.Exists())
            {
                jsonConfiguration.Bind(options);
            }
        });
        // 中文序列化的编码问题
        Configure<AbpSystemTextJsonSerializerOptions>(options =>
        {
            options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
        });
    }

    private void ConfigureMvc(IServiceCollection services, IConfiguration configuration)
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ExposeIntegrationServices = true;
        });

        Configure<AbpEndpointRouterOptions>(options =>
        {
            options.EndpointConfigureActions.Add((builder) =>
            {
                builder.Endpoints.MapHealthChecks(configuration["App:HealthChecks"] ?? "/healthz");
            });
        });

        services.AddHealthChecks();
    }

    private void ConfigureCors(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(DefaultCorsPolicyName, builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .WithAbpWrapExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });



        //        services.AddCors(cors => cors
        //.AddDefaultPolicy(policy => policy
        //.AllowAnyOrigin() // For demo purposes only. Use a specific origin instead.
        //.AllowAnyHeader()
        //.AllowAnyMethod()
        //.WithExposedHeaders("x-elsa-workflow-instance-id"))); // Required for Elsa Studio in order to support running workflows from the designer. Alternatively, you can use the `*` wildcard to expose all headers.


    }

    private void ConfigureSecurity(IServiceCollection services, IConfiguration configuration, bool isDevelopment = false)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = configuration["AuthServer:Authority"];
                   options.RequireHttpsMetadata = false;
                   options.Audience = configuration["AuthServer:ApiName"];
                   options.Events = new JwtBearerEvents
                   {
                       OnMessageReceived = context =>
                       {
                           if (context.Token.IsNullOrWhiteSpace())
                           {
                               var accessToken = context.Request.Query["access_token"];
                               if (!accessToken.IsNullOrEmpty())
                               {
                                   context.Token = accessToken;
                               }
                           }
                           return Task.CompletedTask;
                       }
                   };
               });

        if (!isDevelopment)
        {
            //var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            //services
            //    .AddDataProtection()
            //    .SetApplicationName("ZQH.Abp.Application")
            //    .PersistKeysToStackExchangeRedis(redis, "ZQH.Abp.Application:DataProtection:Protection-Keys");
        }
    }

    private void ConfigureAuditing(IConfiguration configuration)
    {
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = configuration["ApplicationName"];
            // 是否启用实体变更记录
            var allEntitiesSelectorIsEnabled = configuration["Auditing:AllEntitiesSelector"];
            if (allEntitiesSelectorIsEnabled.IsNullOrWhiteSpace() ||
                (bool.TryParse(allEntitiesSelectorIsEnabled, out var enabled) && enabled))
            {
                options.EntityHistorySelectors.AddAllEntities();
            }
        });
    }

    private void ConfigureIdentity(IConfiguration configuration)
    {
        Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            options.IsDynamicClaimsEnabled = true;
            options.RemoteRefreshUrl = configuration["App:RefreshClaimsUrl"] + options.RemoteRefreshUrl;
        });
    }
    private void ConfigureWrapper()
    {
        Configure<AbpWrapperOptions>(options =>
        {
            options.IsEnabled = true;
        });
    }

    private void PreConfigureWrapper()
    {
        //PreConfigure<AbpDaprClientProxyOptions>(options =>
        //{
        //    options.ProxyRequestActions.Add(
        //        (appid, httprequestmessage) =>
        //        {
        //            httprequestmessage.Headers.TryAddWithoutValidation(AbpHttpWrapConsts.AbpDontWrapResult, "true");
        //        });
        //});
        // 服务间调用不包装
        PreConfigure<AbpHttpClientBuilderOptions>(options =>
        {
            options.ProxyClientActions.Add(
                (_, _, client) =>
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(AbpHttpWrapConsts.AbpDontWrapResult, "true");
                });
        });
    }

    private void PreConfigureApp(IConfiguration configuration)
    {
        AbpSerilogEnrichersConsts.ApplicationName = ApplicationName;

        PreConfigure<AbpSerilogEnrichersUniqueIdOptions>(options =>
        {
            // 以开放端口区别
            options.SnowflakeIdOptions.WorkerId = 27;
            options.SnowflakeIdOptions.WorkerIdBits = 5;
            options.SnowflakeIdOptions.DatacenterId = 1;
        });

        if (configuration.GetValue<bool>("App:ShowPii"))
        {
            IdentityModelEventSource.ShowPII = true;
        }
    }

    private void ConfigureMultiTenancy(IConfiguration configuration)
    {
        // 多租户
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });

        var tenantResolveCfg = configuration.GetSection("App:Domains");
        if (tenantResolveCfg.Exists())
        {
            Configure<AbpTenantResolveOptions>(options =>
            {
                var domains = tenantResolveCfg.Get<string[]>();
                foreach (var domain in domains)
                {
                    options.AddDomainTenantResolver(domain);
                }
            });
        }
    }

    private void ConfigureLocalization()
    {
        // 支持本地化语言类型
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));

            // options.Resources
            //.Get<AbpOnboardingResource>()
            //.AddVirtualJson("/Localization/Resources");

            options.UsePersistence<AbpOnboardingResource>();

            // options.Resources
            //.Add<WftextResource>("en")
            //.AddVirtualJson("/Localization/Resources");
            // options.UsePersistence<WftextResource>();
        });

        Configure<AbpLocalizationCultureMapOptions>(options =>
        {
            var zhHansCultureMapInfo = new CultureMapInfo
            {
                TargetCulture = "zh-Hans",
                SourceCultures = new string[] { "zh", "zh_CN", "zh-CN" }
            };

            options.CulturesMaps.Add(zhHansCultureMapInfo);
            options.UiCulturesMaps.Add(zhHansCultureMapInfo);
        });
    }

    private void ConfigureVirtualFileSystem()
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {

            //options.FileSets.AddEmbedded<WorkflowsManagementElsaHttpApiHostModule>("ZQH.Abp.Onboarding");
            options.FileSets.AddEmbedded<WorkflowsManagementElsaHttpApiHostModule>("ZQH.MicroService.Workflows.ElsaHttpApi.Host");

        });
    }
    private void ConfigureTiming(IConfiguration configuration)
    {
        Configure<AbpClockOptions>(options =>
        {
            configuration.GetSection("Clock").Bind(options);
        });
    }
    private void ConfigureCaching(IConfiguration configuration)
    {
        Configure<AbpDistributedCacheOptions>(options =>
        {
            configuration.GetSection("DistributedCache").Bind(options);
        });

        Configure<RedisCacheOptions>(options =>
        {
            var redisConfig = ConfigurationOptions.Parse(options.Configuration);
            options.ConfigurationOptions = redisConfig;
            options.InstanceName = configuration["Redis:InstanceName"];
        });
    }

    private void PreConfigureCAP(IConfiguration configuration)
    {
        PreConfigure<CapOptions>(options =>
        {
            options
            .UseMySql(mySqlOptions =>
            {
                configuration.GetSection("CAP:MySql").Bind(mySqlOptions);
            })
            .UseRabbitMQ(rabbitMQOptions =>
            {
                configuration.GetSection("CAP:RabbitMQ").Bind(rabbitMQOptions);
            })
            .UseDashboard();
        });
    }

    private void PreConfigureQuartz(IConfiguration configuration)
    {
        PreConfigure<AbpQuartzOptions>(options =>
        {
            // 如果使用持久化存储, 则配置quartz持久层
            if (configuration.GetSection("Quartz:UsePersistentStore").Get<bool>())
            {
                var settings = configuration.GetSection("Quartz:Properties").Get<Dictionary<string, string>>();
                if (settings != null)
                {
                    foreach (var setting in settings)
                    {
                        options.Properties[setting.Key] = setting.Value;
                    }
                }

                options.Configurator += (config) =>
                {
                    config.UsePersistentStore(store =>
                    {
                        store.UseProperties = false;
                        store.UseNewtonsoftJsonSerializer();
                    });
                };
            }
        });
    }

    private void ConfigreExceptionHandling()
    {
        // 自定义需要处理的异常
        Configure<AbpExceptionHandlingOptions>(options =>
        {
            //  加入需要处理的异常类型
            options.Handlers.Add<Volo.Abp.Data.AbpDbConcurrencyException>();
            options.Handlers.Add<AbpInitializationException>();
            options.Handlers.Add<ObjectDisposedException>();
            options.Handlers.Add<StackOverflowException>();
            options.Handlers.Add<OutOfMemoryException>();
            options.Handlers.Add<System.Data.Common.DbException>();
            options.Handlers.Add<Microsoft.EntityFrameworkCore.DbUpdateException>();
            options.Handlers.Add<System.Data.DBConcurrencyException>();
        });
    }

    private void ConfigureFeatureManagement()
    {
        Configure<FeatureManagementOptions>(options =>
        {
            options.IsDynamicFeatureStoreEnabled = true;
        });
    }

    private void ConfigureDistributedLocking(IServiceCollection services, IConfiguration configuration)
    {
        var distributedLockEnabled = configuration["DistributedLock:IsEnabled"];
        if (distributedLockEnabled.IsNullOrEmpty() || bool.Parse(distributedLockEnabled))
        {
            var redis = ConnectionMultiplexer.Connect(configuration["DistributedLock:Redis:Configuration"]);
            services.AddSingleton<IDistributedLockProvider>(_ => new RedisDistributedSynchronizationProvider(redis.GetDatabase()));
        }
    }

    private void ConfigureOpenTelemetry(IServiceCollection services, IConfiguration configuration)
    {
        var openTelemetryEnabled = configuration["OpenTelemetry:IsEnabled"];
        if (openTelemetryEnabled.IsNullOrEmpty() || bool.Parse(openTelemetryEnabled))
        {
            services.AddOpenTelemetry()
                .ConfigureResource(resource =>
                {
                    resource.AddService(ApplicationName);
                })
                .WithTracing(tracing =>
                {
                    tracing.AddHttpClientInstrumentation();
                    tracing.AddAspNetCoreInstrumentation();
                    tracing.AddCapInstrumentation();
                    tracing.AddEntityFrameworkCoreInstrumentation();
                    tracing.AddSource(ApplicationName);

                    var tracingOtlpEndpoint = configuration["OpenTelemetry:Otlp:Endpoint"];
                    if (!tracingOtlpEndpoint.IsNullOrWhiteSpace())
                    {
                        tracing.AddOtlpExporter(otlpOptions =>
                        {
                            otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
                        });
                        return;
                    }

                    var zipkinEndpoint = configuration["OpenTelemetry:ZipKin:Endpoint"];
                    if (!zipkinEndpoint.IsNullOrWhiteSpace())
                    {
                        tracing.AddZipkinExporter(zipKinOptions =>
                        {
                            zipKinOptions.Endpoint = new Uri(zipkinEndpoint);
                        });
                        return;
                    }
                })
                .WithMetrics(metrics =>
                {
                    metrics.AddRuntimeInstrumentation();
                    metrics.AddHttpClientInstrumentation();
                    metrics.AddAspNetCoreInstrumentation();
                });
        }
    }


}
