using ZQH.Abp.Notifications.Common;
using Volo.Abp.Modularity;

namespace ZQH.Abp.ExceptionHandling.Notifications;

[DependsOn(
    typeof(AbpExceptionHandlingModule),
    typeof(AbpNotificationsCommonModule))]
public class AbpNotificationsExceptionHandlingModule : AbpModule
{
}
