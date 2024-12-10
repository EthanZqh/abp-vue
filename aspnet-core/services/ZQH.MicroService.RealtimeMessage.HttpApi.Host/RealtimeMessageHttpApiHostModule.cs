using ZQH.Abp.AspNetCore.HttpOverrides;
using ZQH.Abp.AspNetCore.Mvc.Localization;
using ZQH.Abp.AspNetCore.Mvc.Wrapper;
using ZQH.Abp.AuditLogging.Elasticsearch;
using ZQH.Abp.Authorization.OrganizationUnits;
using ZQH.Abp.BackgroundTasks.DistributedLocking;
using ZQH.Abp.BackgroundTasks.ExceptionHandling;
using ZQH.Abp.BackgroundTasks.Quartz;
using ZQH.Abp.Claims.Mapping;
using ZQH.Abp.Data.DbMigrator;
using ZQH.Abp.EventBus.CAP;
using ZQH.Abp.ExceptionHandling.Notifications;
using ZQH.Abp.Features.LimitValidation.Redis;
using ZQH.Abp.Identity.EntityFrameworkCore;
using ZQH.Abp.Identity.Notifications;
using ZQH.Abp.Identity.Session.AspNetCore;
using ZQH.Abp.Identity.WeChat;
using ZQH.Abp.Identity.WeChat.Work;
using ZQH.Abp.IM.SignalR;
using ZQH.Abp.Localization.CultureMap;
using ZQH.Abp.LocalizationManagement.EntityFrameworkCore;
using ZQH.Abp.MessageService;
using ZQH.Abp.MessageService.EntityFrameworkCore;
using ZQH.Abp.Notifications;
using ZQH.Abp.Notifications.Common;
using ZQH.Abp.Notifications.Emailing;
using ZQH.Abp.Notifications.EntityFrameworkCore;
using ZQH.Abp.Notifications.Jobs;
using ZQH.Abp.Notifications.SignalR;
using ZQH.Abp.Notifications.Sms;
using ZQH.Abp.Notifications.WeChat.MiniProgram;
using ZQH.Abp.Notifications.WeChat.Work;
using ZQH.Abp.Notifications.WxPusher;
using ZQH.Abp.Saas.EntityFrameworkCore;
using ZQH.Abp.Serilog.Enrichers.Application;
using ZQH.Abp.Serilog.Enrichers.UniqueId;
using ZQH.Abp.TaskManagement.EntityFrameworkCore;
using ZQH.Abp.TextTemplating.EntityFrameworkCore;
using ZQH.Abp.TextTemplating.Scriban;
using ZQH.Abp.WeChat.Official.Handlers;
using ZQH.Abp.WeChat.Work.Handlers;
using ZQH.MicroService.RealtimeMessage.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace ZQH.MicroService.RealtimeMessage;

[DependsOn(
    typeof(AbpSerilogEnrichersApplicationModule),
    typeof(AbpSerilogEnrichersUniqueIdModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpAuditLoggingElasticsearchModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpAspNetCoreMvcLocalizationModule),
    typeof(AbpMessageServiceApplicationModule),
    typeof(AbpMessageServiceHttpApiModule),
    typeof(AbpNotificationsApplicationModule),
    typeof(AbpNotificationsHttpApiModule),
    typeof(AbpIdentityWeChatModule),
    typeof(AbpIdentityWeChatWorkModule),
    typeof(AbpBackgroundTasksQuartzModule),
    typeof(AbpBackgroundTasksDistributedLockingModule),
    typeof(AbpBackgroundTasksExceptionHandlingModule),
    typeof(TaskManagementEntityFrameworkCoreModule),
    typeof(AbpMessageServiceEntityFrameworkCoreModule),
    typeof(AbpNotificationsEntityFrameworkCoreModule),
    typeof(AbpSaasEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpLocalizationManagementEntityFrameworkCoreModule),
    typeof(AbpTextTemplatingEntityFrameworkCoreModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(RealtimeMessageMigrationsEntityFrameworkCoreModule),
    typeof(AbpDataDbMigratorModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpAuthorizationOrganizationUnitsModule),
    typeof(AbpBackgroundWorkersModule),
    typeof(AbpIMSignalRModule),
    typeof(AbpNotificationsJobsModule),
    typeof(AbpNotificationsCommonModule),
    typeof(AbpNotificationsSmsModule),
    typeof(AbpNotificationsEmailingModule),
    typeof(AbpNotificationsSignalRModule),
    typeof(AbpNotificationsWxPusherModule),
    typeof(AbpNotificationsWeChatMiniProgramModule),
    typeof(AbpNotificationsWeChatWorkModule),
    typeof(AbpNotificationsExceptionHandlingModule),
    typeof(AbpWeChatWorkHandlersModule),
    typeof(AbpWeChatOfficialHandlersModule),
    typeof(AbpIdentityNotificationsModule),

    // 重写模板引擎支持外部本地化
    typeof(AbpTextTemplatingScribanModule),

    typeof(AbpCAPEventBusModule),
    typeof(AbpFeaturesValidationRedisModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpLocalizationCultureMapModule),
    typeof(AbpIdentitySessionAspNetCoreModule),
    typeof(AbpHttpClientModule),
    typeof(AbpClaimsMappingModule),
    typeof(AbpAspNetCoreMvcWrapperModule),
    typeof(AbpAspNetCoreHttpOverridesModule),
    typeof(AbpAutofacModule)
    )]
public partial class RealtimeMessageHttpApiHostModule : AbpModule
{
    private const string DefaultCorsPolicyName = "Default";

    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        PreConfigureWrapper();
        PreConfigureFeature();
        PreForwardedHeaders();
        PreConfigureApp(configuration);
        PreConfigureCAP(configuration);
        PreConfigureQuartz(configuration);
        PreConfigureSignalR(configuration);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureWrapper();
        ConfigureDbContext();
        ConfigureLocalization();
        ConfigureNotifications();
        ConfigureTextTemplating();
        ConfigureExceptionHandling();
        ConfigureVirtualFileSystem();
        ConfigureFeatureManagement();
        ConfigureTiming(configuration);
        ConfigureCaching(configuration);
        ConfigureAuditing(configuration);
        ConfigureIdentity(configuration);
        ConfigureMultiTenancy(configuration);
        ConfigureJsonSerializer(configuration);
        ConfigureBackgroundTasks(configuration);
        ConfigureSwagger(context.Services);
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
        app.UseForwardedHeaders();
        // 本地化
        app.UseMapRequestLocalization();
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
        app.UseAbpSession();
        app.UseDynamicClaims();
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
