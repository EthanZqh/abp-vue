using Volo.Abp.Application.Services;

namespace ZQH.Abp.DataProtectionManagement;
public abstract class DataProtectionManagementApplicationServiceBase : ApplicationService
{
    protected DataProtectionManagementApplicationServiceBase()
    {
        LocalizationResource = typeof(AbpDataProtectionManagementApplicationModule);
        ObjectMapperContext = typeof(AbpDataProtectionManagementApplicationModule);
    }
}
