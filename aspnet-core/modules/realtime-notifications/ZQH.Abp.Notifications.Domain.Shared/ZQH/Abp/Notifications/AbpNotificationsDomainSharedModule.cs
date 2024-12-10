using ZQH.Abp.Notifications.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Users;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.Notifications;

[DependsOn(
    typeof(AbpNotificationsCoreModule),
    typeof(AbpUsersDomainSharedModule))]
public class AbpNotificationsDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpNotificationsDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<NotificationsResource>()
                .AddVirtualJson("/ZQH.Abp/Notifications/Localization/DomainShared");
        });
    }
}
