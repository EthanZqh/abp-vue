using ZQH.Abp.OssManagement.Localization;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.OssManagement;

public abstract class OssManagementApplicationServiceBase : ApplicationService
{
    protected OssManagementApplicationServiceBase()
    {
        LocalizationResource = typeof(AbpOssManagementResource);
        ObjectMapperContext = typeof(AbpOssManagementApplicationModule);
    }
}
