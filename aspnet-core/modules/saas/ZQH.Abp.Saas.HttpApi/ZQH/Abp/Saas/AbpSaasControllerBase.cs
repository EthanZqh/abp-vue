using ZQH.Abp.Saas.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ZQH.Abp.Saas;
public abstract class AbpSaasControllerBase : AbpControllerBase
{
    protected AbpSaasControllerBase()
    {
        LocalizationResource = typeof(AbpSaasResource);
    }
}
