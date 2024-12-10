using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.PermissionManagement.Localization;

namespace ZQH.Abp.PermissionManagement.HttpApi;
public abstract class PermissionManagementControllerBase : AbpControllerBase
{
    protected PermissionManagementControllerBase()
    {
        LocalizationResource = typeof(AbpPermissionManagementResource);
    }
}
