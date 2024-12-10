using ZQH.Abp.BackgroundTasks.Activities;
using ZQH.Abp.BackgroundTasks.Localization;
using ZQH.Abp.Notifications;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.BackgroundTasks.Notifications;

[DependsOn(
    typeof(AbpBackgroundTasksActivitiesModule),
    typeof(AbpNotificationsModule))]
public class AbpBackgroundTasksNotificationsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpBackgroundTasksNotificationsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BackgroundTasksResource>()
                .AddVirtualJson("/ZQH.Abp.BackgroundTasks/Notifications/Localization/Resources");
        });
    }
}
