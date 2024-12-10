using ZQH.Abp.Notifications.Localization;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.Notifications;

public abstract class AbpNotificationsApplicationServiceBase : ApplicationService
{
    protected AbpNotificationsApplicationServiceBase()
    {
        LocalizationResource = typeof(NotificationsResource);
        ObjectMapperContext = typeof(AbpNotificationsApplicationModule);
    }
}
