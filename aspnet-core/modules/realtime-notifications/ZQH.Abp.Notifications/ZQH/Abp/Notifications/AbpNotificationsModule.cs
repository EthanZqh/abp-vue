﻿using ZQH.Abp.IdGenerator;
using ZQH.Abp.Notifications.Localization;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.EventBus;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.Notifications;

[DependsOn(
    typeof(AbpNotificationsCoreModule),
    typeof(AbpBackgroundWorkersModule),
    typeof(AbpBackgroundJobsAbstractionsModule),
    typeof(AbpIdGeneratorModule),
    typeof(AbpLocalizationModule),
    typeof(AbpEventBusModule),
    typeof(AbpTextTemplatingCoreModule))]
public class AbpNotificationsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpNotificationsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<NotificationsResource>()
                .AddVirtualJson("/ZQH.Abp/Notifications/Localization/Resources");
        });
    }
}