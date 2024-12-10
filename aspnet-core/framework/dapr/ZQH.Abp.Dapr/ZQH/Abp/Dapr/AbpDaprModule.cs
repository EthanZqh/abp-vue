using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Dapr;

[DependsOn(typeof(AbpJsonModule))]
public class AbpDaprModule : AbpModule
{
}
