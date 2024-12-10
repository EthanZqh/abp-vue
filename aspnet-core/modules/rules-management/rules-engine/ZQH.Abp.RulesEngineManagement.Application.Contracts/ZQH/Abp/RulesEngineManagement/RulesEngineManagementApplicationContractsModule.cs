using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace ZQH.Abp.RulesEngineManagement;

[DependsOn(
    typeof(RulesEngineManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule))]
public class RulesEngineManagementApplicationContractsModule : AbpModule
{

}
