//using ZQH.Abp.AspNetCore.HttpOverrides;
//using ZQH.Abp.AspNetCore.Mvc.Localization;
//using ZQH.Abp.AspNetCore.Mvc.Wrapper;
//using ZQH.Abp.AuditLogging.Elasticsearch;
//using ZQH.Abp.Authorization.OrganizationUnits;
//using ZQH.Abp.Data.DbMigrator;
//using ZQH.Abp.Http.Client.Wrapper;
//using ZQH.Abp.Identity.EntityFrameworkCore;
//using ZQH.Abp.Localization.CultureMap;
//using ZQH.Abp.LocalizationManagement.EntityFrameworkCore;
//using ZQH.Abp.Saas.EntityFrameworkCore;
//using ZQH.Abp.Serilog.Enrichers.Application;
//using ZQH.Abp.Serilog.Enrichers.UniqueId;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ProductManagement;
using ProductManagement.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.Threading;
using ZQH.Abp.AspNetCore.HttpOverrides;
using ZQH.Abp.AspNetCore.Mvc.Localization;
using ZQH.Abp.AspNetCore.Mvc.Wrapper;
using ZQH.Abp.AuditLogging.Elasticsearch;
using ZQH.Abp.Authorization.OrganizationUnits;
using ZQH.Abp.Data.DbMigrator;
using ZQH.Abp.Http.Client.Wrapper;
using ZQH.Abp.Identity.EntityFrameworkCore;
using ZQH.Abp.Localization.CultureMap;
using ZQH.Abp.LocalizationManagement.EntityFrameworkCore;
using ZQH.Abp.Saas.EntityFrameworkCore;
using ZQH.Abp.Serilog.Enrichers.Application;
using ZQH.Abp.Serilog.Enrichers.UniqueId;

namespace ZQH.MicroService.Product.HttpApi.Host;
[DependsOn(
    typeof(AbpSerilogEnrichersApplicationModule),
    typeof(AbpSerilogEnrichersUniqueIdModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAuditLoggingElasticsearchModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpAspNetCoreMvcLocalizationModule),
    typeof(AbpSaasEntityFrameworkCoreModule),
    typeof(AbpLocalizationManagementEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(ProductManagementApplicationModule),
    typeof(ProductManagementHttpApiModule),
    typeof(ProductManagementEntityFrameworkCoreModule),
    //typeof(ProductMigrationsEntityFrameworkCoreModule),
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
    typeof(AbpAutofacModule)
    )]

public partial class ProductHttpApiHostModule:AbpModule
{
    private const string DefaultCorsPolicyName = "Default";
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        PreConfigureApp();
        //PreConfigureFeature();
        PreConfigureCAP(configuration);
        //PreConfigureQuartz(configuration);
        //PreConfigureSignalR(configuration);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureDbContext();
        ConfigureLocalization();
        ConfigreExceptionHandling();
        ConfigureVirtualFileSystem();
        //ConfigureFeatureManagement();
        ConfigureCaching(configuration);
        ConfigureAuditing(configuration);
        ConfigureSwagger(context.Services);
        ConfigureMultiTenancy(configuration);
        ConfigureJsonSerializer(configuration);
        ConfigureCors(context.Services, configuration);
        ConfigureDistributedLocking(context.Services, configuration);
        ConfigureSeedWorker(context.Services, hostingEnvironment.IsDevelopment());
        ConfigureSecurity(context.Services, configuration, hostingEnvironment.IsDevelopment());
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
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
        app.UseAbpClaimsMap();
        // jwt
        app.UseJwtTokenMiddleware();
        // 多租户
        app.UseMultiTenancy();
        // 本地化
        app.UseMapRequestLocalization();
        // 授权
        app.UseAuthorization();
        // Swagger
        app.UseSwagger();
        // Swagger可视化界面
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support Realtime Message API");
        });
        // 审计日志
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        // 路由
        app.UseConfiguredEndpoints();
    }
}
