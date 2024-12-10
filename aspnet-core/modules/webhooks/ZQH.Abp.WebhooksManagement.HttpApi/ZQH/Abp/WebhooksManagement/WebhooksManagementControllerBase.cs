using ZQH.Abp.WebhooksManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ZQH.Abp.WebhooksManagement;

public abstract class WebhooksManagementControllerBase : AbpControllerBase
{
    protected WebhooksManagementControllerBase()
    {
        LocalizationResource = typeof(WebhooksManagementResource);
    }
}
