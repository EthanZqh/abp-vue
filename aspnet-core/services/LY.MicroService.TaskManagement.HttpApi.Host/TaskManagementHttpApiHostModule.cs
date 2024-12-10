using ZQH.Abp.AspNetCore.HttpOverrides;
using ZQH.Abp.AspNetCore.Mvc.Localization;
using ZQH.Abp.AspNetCore.Mvc.Wrapper;
using ZQH.Abp.AuditLogging.Elasticsearch;
using ZQH.Abp.Authorization.OrganizationUnits;
using ZQH.Abp.BackgroundTasks.DistributedLocking;
using ZQH.Abp.BackgroundTasks.ExceptionHandling;
using ZQH.Abp.BackgroundTasks.Jobs;
using ZQH.Abp.BackgroundTasks.Notifications;
using ZQH.Abp.BackgroundTasks.Quartz;
using ZQH.Abp.Claims.Mapping;
using ZQH.Abp.Data.DbMigrator;
using ZQH.Abp.EventBus.CAP;
using ZQH.Abp.ExceptionHandling.Emailing;
using ZQH.Abp.Localization.CultureMap;
using ZQH.Abp.LocalizationManagement.EntityFrameworkCore;
using ZQH.Abp.OssManagement;
using ZQH.Abp.Saas.EntityFrameworkCore;
using ZQH.Abp.Serilog.Enrichers.Application;
using ZQH.Abp.Serilog.Enrichers.UniqueId;
using ZQH.Abp.TaskManagement;
using ZQH.Abp.TaskManagement.EntityFrameworkCore;
using ZQH.MicroService.TaskManagement.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;

namespace ZQH.MicroService.TaskManagement;

[DependsOn(
    typeof(AbpSerilogEnrichersApplicationModule),
    typeof(AbpSerilogEnrichersUniqueIdModule),
    typeof(AbpAuditLoggingElasticsearchModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpAuthorizationOrganizationUnitsModule),
    typeof(AbpEmailingExceptionHandlingModule),
    typeof(AbpOssManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelWebModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpAspNetCoreMvcLocalizationModule),
    typeof(AbpBackgroundTasksJobsModule),
    typeof(AbpBackgroundTasksQuartzModule),
    typeof(AbpBackgroundTasksDistributedLockingModule),
    typeof(AbpBackgroundTasksExceptionHandlingModule),
    typeof(AbpBackgroundTasksNotificationsModule),
    typeof(TaskManagementApplicationModule),
    typeof(TaskManagementHttpApiModule),
    typeof(TaskManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpSaasEntityFrameworkCoreModule),
    typeof(AbpLocalizationManagementEntityFrameworkCoreModule),
    typeof(TaskManagementMigrationsEntityFrameworkCoreModule),
    typeof(AbpDataDbMigratorModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpLocalizationCultureMapModule),
    typeof(AbpAspNetCoreMvcWrapperModule),
    typeof(AbpAspNetCoreHttpOverridesModule),
    typeof(AbpClaimsMappingModule),
    typeof(AbpCAPEventBusModule),
    typeof(AbpAutofacModule)
    )]
public partial class TaskManagementHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        PreConfigureWrapper();
        PreConfigureFeature();
        PreForwardedHeaders();
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
        ConfigureLocalization();
        ConfigureBackgroundTasks();
        ConfigureExceptionHandling();
        ConfigureVirtualFileSystem();
        ConfigureFeatureManagement();
        ConfigureTiming(configuration);
        ConfigureCaching(configuration);
        ConfigureAuditing(configuration);
        ConfigureIdentity(configuration);
        ConfigureMultiTenancy(configuration);
        ConfigureSwagger(context.Services);
        ConfigureJsonSerializer(configuration);
        ConfigureMvc(context.Services, configuration);
        ConfigureCors(context.Services, configuration);
        ConfigureOpenTelemetry(context.Services, configuration);
        ConfigureDistributedLock(context.Services, configuration);
        ConfigureSecurity(context.Services, configuration, hostingEnvironment.IsDevelopment());
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        app.UseForwardedHeaders();
        app.UseAbpRequestLocalization();
        app.UseStaticFiles();
        app.UseCorrelationId();
        app.UseRouting();
        app.UseCors(DefaultCorsPolicyName);
        app.UseAuthentication();
        app.UseJwtTokenMiddleware();
        app.UseMultiTenancy();
        app.UseDynamicClaims();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support Task Management API");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            options.OAuthScopes(configuration["AuthServer:Scopes"]);
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
