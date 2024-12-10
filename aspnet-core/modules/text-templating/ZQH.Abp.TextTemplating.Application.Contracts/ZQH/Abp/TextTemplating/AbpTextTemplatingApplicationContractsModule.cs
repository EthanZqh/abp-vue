using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace ZQH.Abp.TextTemplating;

[DependsOn(
    typeof(AbpTextTemplatingDomainSharedModule),
    typeof(AbpAuthorizationAbstractionsModule),
    typeof(AbpDddApplicationContractsModule))]
public class AbpTextTemplatingApplicationContractsModule : AbpModule
{

}
