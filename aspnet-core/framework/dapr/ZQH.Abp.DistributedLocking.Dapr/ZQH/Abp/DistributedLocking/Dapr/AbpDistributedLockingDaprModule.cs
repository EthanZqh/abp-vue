using ZQH.Abp.Dapr;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace ZQH.Abp.DistributedLocking.Dapr;

[DependsOn(
    typeof(AbpDaprModule),
    typeof(AbpThreadingModule),
    typeof(AbpDistributedLockingAbstractionsModule))]
public class AbpDistributedLockingDaprModule : AbpModule
{

}
