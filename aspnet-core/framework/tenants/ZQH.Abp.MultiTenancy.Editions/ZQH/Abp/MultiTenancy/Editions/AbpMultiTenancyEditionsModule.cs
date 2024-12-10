using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace ZQH.Abp.MultiTenancy.Editions;

[DependsOn(typeof(AbpMultiTenancyModule))]
public class AbpMultiTenancyEditionsModule : AbpModule
{
}
