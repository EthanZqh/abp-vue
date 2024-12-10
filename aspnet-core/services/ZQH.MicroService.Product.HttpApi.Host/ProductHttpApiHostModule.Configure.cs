using DotNetCore.CAP;
//using ZQH.Abp.ExceptionHandling;
//using ZQH.Abp.Localization.CultureMap;
//using ZQH.Abp.Serilog.Enrichers.Application;
//using ZQH.Abp.Serilog.Enrichers.UniqueId;
using Medallion.Threading.Redis;
using Medallion.Threading;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Quartz;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Caching;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Json;
using Volo.Abp.Json.SystemTextJson;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;
using ProductManagement.Localization;
using ZQH.Abp.Serilog.Enrichers.UniqueId;
using ZQH.Abp.Serilog.Enrichers.Application;
using ZQH.Abp.ExceptionHandling;
using ZQH.Abp.Localization.CultureMap;

namespace ZQH.MicroService.Product.HttpApi.Host;

public partial class ProductHttpApiHostModule
{
    protected const string ApplicationName = "ProductService";

    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    private void PreConfigureFeature()
    {
        OneTimeRunner.Run(() =>
        {
            GlobalFeatureManager.Instance.Modules.Editions().EnableAll();
        });
    }

    private void PreConfigureApp()
    {
        AbpSerilogEnrichersConsts.ApplicationName = ApplicationName;

        PreConfigure<AbpSerilogEnrichersUniqueIdOptions>(options =>
        {
            // 以开放端口区别，应在0-31之间
            options.SnowflakeIdOptions.WorkerId = 20;
            options.SnowflakeIdOptions.WorkerIdBits = 5;
            options.SnowflakeIdOptions.DatacenterId = 1;
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

    //private void PreConfigureQuartz(IConfiguration configuration)
    //{
    //    PreConfigure<AbpQuartzOptions>(options =>
    //    {
    //        // 如果使用持久化存储, 则配置quartz持久层
    //        if (configuration.GetSection("Quartz:UsePersistentStore").Get<bool>())
    //        {
    //            var settings = configuration.GetSection("Quartz:Properties").Get<Dictionary<string, string>>();
    //            if (settings != null)
    //            {
    //                foreach (var setting in settings)
    //                {
    //                    options.Properties[setting.Key] = setting.Value;
    //                }
    //            }

    //            options.Configurator += (config) =>
    //            {
    //                config.UsePersistentStore(store =>
    //                {
    //                    store.UseProperties = false;
    //                    store.UseJsonSerializer();
    //                });
    //            };
    //        }
    //    });
    //}

    //private void ConfigureBackgroundTasks()
    //{
    //    Configure<AbpBackgroundTasksOptions>(options =>
    //    {
    //        options.NodeName = ApplicationName;

    //        options.JobDispatcherSelectors.AddJob<NotificationPublishJob>(
    //            job =>
    //            {
    //                job.Interval = 10;
    //                job.MaxTryCount = 10;
    //                job.NodeName = ApplicationName;
    //            });
    //    });
    //}

    private void ConfigureDbContext()
    {
        // 配置Ef
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
        });
    }

    //private void ConfigureFeatureManagement()
    //{
    //    Configure<FeatureManagementOptions>(options =>
    //    {
    //        options.IsDynamicFeatureStoreEnabled = true;
    //    });
    //}

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

    private void ConfigureAuditing(IConfiguration configuration)
    {
        Configure<AbpAuditingOptions>(options =>
        {
            options.ApplicationName = ApplicationName;
            // 是否启用实体变更记录
            var allEntitiesSelectorIsEnabled = configuration["Auditing:AllEntitiesSelector"];
            if (allEntitiesSelectorIsEnabled.IsNullOrWhiteSpace() ||
                (bool.TryParse(allEntitiesSelectorIsEnabled, out var enabled) && enabled))
            {
                options.EntityHistorySelectors.AddAllEntities();
            }
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

    private void PreConfigureSignalR(IConfiguration configuration)
    {
        PreConfigure<ISignalRServerBuilder>(builder =>
        {
            var redisEnabled = configuration["SignalR:Redis:IsEnabled"];
            if (redisEnabled.IsNullOrEmpty() || bool.Parse(redisEnabled))
            {
                builder.AddStackExchangeRedis(redis =>
                {
                    var redisConfiguration = configuration["SignalR:Redis:Configuration"];
                    if (!redisConfiguration.IsNullOrEmpty())
                    {
                        redis.ConnectionFactory = async (writer) =>
                        {
                            return await ConnectionMultiplexer.ConnectAsync(redisConfiguration);
                        };
                    }
                });
            }
        });
    }

    private void ConfigureVirtualFileSystem()
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ProductHttpApiHostModule>("ZQH.MicroService.Product.HttpApi.Host");
        });
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

    private void ConfigureSwagger(IServiceCollection services)
    {
        // Swagger
        services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
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
                    // 引用 ZQH.Abp.AspNetCore.Mvc.Wrapper 包时可替换为 WithAbpWrapExposedHeaders
                    .WithExposedHeaders("_AbpWrapResult", "_AbpDontWrapResult")
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    private void ConfigureLocalization()
    {
        // 支持本地化语言类型
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));

            options.UsePersistence<ProductApiResource>();

            // options.Resources
            //.Add<ATestResource>("en")
            //.AddVirtualJson("/Localization/Resources");
            // options.UsePersistence<ATestResource>();


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

        if (isDevelopment)
        {
            // services.AddAlwaysAllowAuthorization();
        }

        if (!isDevelopment)
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            services
                .AddDataProtection()
                .SetApplicationName("ZQH.Abp.Application")
                .PersistKeysToStackExchangeRedis(redis, "ZQH.Abp.Application:DataProtection:Protection-Keys");
        }
    }
}
