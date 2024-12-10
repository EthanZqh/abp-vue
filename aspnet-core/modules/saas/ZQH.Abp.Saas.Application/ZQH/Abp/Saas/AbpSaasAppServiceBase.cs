using ZQH.Abp.Saas.Localization;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.Saas;
public abstract class AbpSaasAppServiceBase : ApplicationService
{
    protected AbpSaasAppServiceBase()
    {
        ObjectMapperContext = typeof(AbpSaasApplicationModule);
        LocalizationResource = typeof(AbpSaasResource);
    }
}
