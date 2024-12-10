using ZQH.Abp.PushPlus;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Notifications.PushPlus;

[DependsOn(
    typeof(AbpNotificationsModule),
    typeof(AbpPushPlusModule))]
public class AbpNotificationsPushPlusModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNotificationsPublishOptions>(options =>
        {
            options.PublishProviders.Add<PushPlusNotificationPublishProvider>();
        });
    }
}
