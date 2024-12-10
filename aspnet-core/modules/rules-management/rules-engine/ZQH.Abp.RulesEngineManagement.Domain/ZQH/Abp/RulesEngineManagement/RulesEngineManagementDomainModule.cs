using ZQH.Abp.Rules.RulesEngine;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ZQH.Abp.RulesEngineManagement;

[DependsOn(
    typeof(RulesEngineManagementDomainSharedModule),
    typeof(AbpRulesEngineModule),
    typeof(AbpDddDomainModule))]
public class RulesEngineManagementDomainModule : AbpModule
{

}
