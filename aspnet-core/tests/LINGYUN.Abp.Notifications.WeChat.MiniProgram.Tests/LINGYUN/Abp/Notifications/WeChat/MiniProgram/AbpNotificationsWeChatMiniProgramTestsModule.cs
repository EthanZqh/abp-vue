using LINGYUN.Abp.Tests;
using Volo.Abp.Modularity;

namespace LINGYUN.Abp.Notifications.WeChat.MiniProgram
{
    [DependsOn(
        typeof(AbpNotificationsWeChatMiniProgramModule),
        typeof(AbpNotificationsTestsModule),
        typeof(AbpTestsBaseModule))]
    public class AbpNotificationsWeChatMiniProgramTestsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpNotificationsWeChatMiniProgramOptions>(options =>
            {
                options.DefaultMsgPrefix = "[wmp-override]";
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // �Զ������ݴ�������
            Configure<AbpNotificationsPublishOptions>(options =>
            {
                // ����֪ͨ���ر�׼����֪ͨ
                options.NotificationDataMappings
                    .Mapping(
                        WeChatMiniProgramNotificationPublishProvider.ProviderName,
                        NotificationsTestsNames.Test2,
                        data => NotificationData.ToStandardData(data));

                // ����֪ͨ�����κδ���
                options.NotificationDataMappings
                    .Mapping(
                        WeChatMiniProgramNotificationPublishProvider.ProviderName,
                        NotificationsTestsNames.Test3,
                        data => data);
            });
        }
    }
}