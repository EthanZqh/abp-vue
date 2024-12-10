using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ZQH.Abp.DataProtection.EntityFrameworkCore;

[DependsOn(
    typeof(AbpDataProtectionModule),
    typeof(AbpEntityFrameworkCoreModule))]
public class AbpDataProtectionEntityFrameworkCoreModule : AbpModule
{
}
