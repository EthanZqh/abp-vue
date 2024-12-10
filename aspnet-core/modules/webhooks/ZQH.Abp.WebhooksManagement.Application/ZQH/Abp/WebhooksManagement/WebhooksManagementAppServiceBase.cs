using ZQH.Abp.WebhooksManagement.Localization;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.WebhooksManagement;

public abstract class WebhooksManagementAppServiceBase : ApplicationService
{
    protected WebhooksManagementAppServiceBase()
    {
        LocalizationResource = typeof(WebhooksManagementResource);
        ObjectMapperContext = typeof(WebhooksManagementApplicationModule);
    }
}
