using Volo.Abp.Modularity;
using VoloAbpPermissionManagementApplicationModule = Volo.Abp.PermissionManagement.AbpPermissionManagementApplicationModule;

namespace ZQH.Abp.PermissionManagement;

[DependsOn(
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(VoloAbpPermissionManagementApplicationModule))]
public class AbpPermissionManagementApplicationModule : AbpModule
{

}
