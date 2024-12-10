using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.NewtonsoftJson;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Http.Client;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
using ZQH.Abp.AspNetCore.HttpOverrides;
using ZQH.Abp.AspNetCore.Mvc.Localization;
using ZQH.Abp.AspNetCore.Mvc.Wrapper;
using ZQH.Abp.AuditLogging.Elasticsearch;
using ZQH.Abp.Authorization.OrganizationUnits;
using ZQH.Abp.Data.DbMigrator;
using ZQH.Abp.EventBus.CAP;
using ZQH.Abp.Http.Client.Wrapper;
using ZQH.Abp.Identity.EntityFrameworkCore;
using ZQH.Abp.Identity.Session.AspNetCore;
using ZQH.Abp.Localization.CultureMap;
using ZQH.Abp.LocalizationManagement.EntityFrameworkCore;
using ZQH.Abp.Onboarding;
using ZQH.Abp.Onboarding.EntityFrameworkCore;
using ZQH.Abp.Saas.EntityFrameworkCore;
using ZQH.Abp.Serilog.Enrichers.Application;
using ZQH.Abp.Serilog.Enrichers.UniqueId;
using ZQH.MicroService.Onboarding.EntityFrameworkCore;

namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host;
[DependsOn(
    typeof(AbpSerilogEnrichersApplicationModule),
    typeof(AbpSerilogEnrichersUniqueIdModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAuditLoggingElasticsearchModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpAspNetCoreMvcLocalizationModule),
    typeof(AbpDistributedLockingModule),
    //typeof(AbpUINavigationVueVbenAdminModule),
    //typeof(PlatformThemeVueVbenAdminModule),
    // typeof(AbpOssManagementAliyunModule),
    //typeof(AbpOssManagementFileSystemModule),           // 本地文件系统提供者模块
    //typeof(AbpOssManagementFileSystemImageSharpModule), // 本地文件系统图形处理模块
    //typeof(AbpOssManagementApplicationModule),
    //typeof(AbpOssManagementHttpApiModule),
    //typeof(AbpOssManagementSettingManagementModule),
    //typeof(PlatformApplicationModule),
    //typeof(PlatformHttpApiModule),
    //typeof(PlatformEntityFrameworkCoreModule),
    //typeof(AbpIdentityHttpApiClientModule),
    //typeof(AbpHttpClientIdentityModelWebModule),
    //typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpSaasEntityFrameworkCoreModule),
    //typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpLocalizationManagementEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    //typeof(PlatformMigrationsEntityFrameworkCoreModule),

        //typeof(AbpNotificationsModule),
        //typeof(AbpEmailingExceptionHandlingModule),
        typeof(AbpCAPEventBusModule),
        //typeof(AbpFeaturesValidationRedisModule),
        // typeof(AbpFeaturesClientModule),// 当需要客户端特性限制时取消注释此模块
        // typeof(AbpFeaturesValidationRedisClientModule),// 当需要客户端特性限制时取消注释此模块
    
      
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpIdentitySessionAspNetCoreModule),
        typeof(AbpHttpClientModule),

        //typeof(AbpClaimsMappingModule),

        typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAspNetCoreMvcNewtonsoftModule),
           typeof(AbpOnboardingHttpApiModule),
           typeof(AbpOnboardingApplicationModule),
    typeof(AbpOnboardingEntityFrameworkCoreModule),
    typeof(OnboardingMigrationsEntityFrameworkCoreModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpDataDbMigratorModule),
    typeof(AbpAuthorizationOrganizationUnitsModule),
    typeof(AbpBackgroundWorkersModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreHttpOverridesModule),
    typeof(AbpLocalizationCultureMapModule),
    typeof(AbpHttpClientWrapperModule),
    typeof(AbpAspNetCoreMvcWrapperModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpAutofacModule),

    typeof(AbpLocalizationModule)


 

    //typeof(AbpClaimsMappingModule),






    )]

public partial class WorkflowsManagementElsaHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        PreConfigureWrapper();
        //PreForwardedHeaders();
        //PreConfigureFeature();
        PreConfigureApp(configuration);
        PreConfigureCAP(configuration);
        PreConfigureQuartz(configuration);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureWrapper();
        ConfigureDbContext();
        //ConfigureBlobStoring();
        ConfigureLocalization();
        //ConfigureKestrelServer();
        ConfigreExceptionHandling();
        ConfigureVirtualFileSystem();



        ConfigureFeatureManagement();
        ConfigureTiming(configuration);
        ConfigureCaching(configuration);
        ConfigureIdentity(configuration);
        ConfigureAuditing(configuration);
        ConfigureSwagger(context.Services);
        ConfigureMultiTenancy(configuration);
        ConfigureJsonSerializer(configuration);
        ConfigureMvc(context.Services, configuration);
        ConfigureCors(context.Services, configuration);
        ConfigureOpenTelemetry(context.Services, configuration);
        ConfigureDistributedLocking(context.Services, configuration);

        ConfigureSeedWorker(context.Services, hostingEnvironment.IsDevelopment());
        ConfigureSecurity(context.Services, configuration, hostingEnvironment.IsDevelopment());

    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.UseForwardedHeaders();
        // 本地化
        //app.UseMapRequestLocalization();
        app.UseAbpRequestLocalization();
        // http调用链
        app.UseCorrelationId();
        // 虚拟文件系统
        app.UseStaticFiles();
        // 路由
        app.UseRouting();
        // 跨域
        app.UseCors(DefaultCorsPolicyName);
        // 认证
        app.UseAuthentication();
        app.UseJwtTokenMiddleware();
        // 多租户
        app.UseMultiTenancy();
        // 会话
        //app.UseAbpSession();
        app.UseDynamicClaims();
        // 授权
        app.UseAuthorization();
        // Swagger
        app.UseSwagger();
        // Swagger可视化界面
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support Platform API");
        });
        //app.UseAbpSwaggerUI(options =>
        //{
        //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support Task Management API");

        //    //var configuration = context.GetConfiguration();
        //    //options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        //    //options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
        //    //options.OAuthScopes(configuration["AuthServer:Scopes"]);
        //});

        // 审计日志
        app.UseAuditing();
        // 记录请求信息
        app.UseAbpSerilogEnrichers();
        // 路由
        app.UseConfiguredEndpoints();


        //app.UseHttpsRedirection();

 



    }
}
