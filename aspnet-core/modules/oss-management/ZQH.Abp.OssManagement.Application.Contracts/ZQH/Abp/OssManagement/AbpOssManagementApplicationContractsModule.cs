using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace ZQH.Abp.OssManagement;

[DependsOn(
    typeof(AbpOssManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule))]
public class AbpOssManagementApplicationContractsModule : AbpModule
{
}
