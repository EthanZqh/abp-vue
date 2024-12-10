using ZQH.Abp.LocalizationManagement.Localization;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.LocalizationManagement;

public abstract class LocalizationAppServiceBase : ApplicationService
{
    protected LocalizationAppServiceBase()
    {
        LocalizationResource = typeof(LocalizationManagementResource);
        ObjectMapperContext = typeof(AbpLocalizationManagementApplicationModule);
    }
}
