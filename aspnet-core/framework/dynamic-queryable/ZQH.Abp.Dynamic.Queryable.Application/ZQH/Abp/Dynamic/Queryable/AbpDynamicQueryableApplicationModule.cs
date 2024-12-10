using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Dynamic.Queryable;

[DependsOn(
    typeof(AbpDynamicQueryableApplicationContractsModule),
    typeof(AbpDddApplicationModule))]
public class AbpDynamicQueryableApplicationModule : AbpModule
{
}
