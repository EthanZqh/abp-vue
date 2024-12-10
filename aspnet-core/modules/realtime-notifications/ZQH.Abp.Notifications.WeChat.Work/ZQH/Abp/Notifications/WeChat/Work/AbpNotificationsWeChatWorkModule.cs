using ZQH.Abp.WeChat.Work;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Notifications.WeChat.Work;

[DependsOn(
    typeof(AbpWeChatWorkModule),
    typeof(AbpNotificationsModule))]
public class AbpNotificationsWeChatWorkModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNotificationsPublishOptions>(options =>
        {
            options.PublishProviders.Add<WeChatWorkNotificationPublishProvider>();
        });
    }
}
