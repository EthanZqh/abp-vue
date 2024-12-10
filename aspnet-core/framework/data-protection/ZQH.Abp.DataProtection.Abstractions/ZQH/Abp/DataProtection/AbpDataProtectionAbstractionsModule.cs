using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace ZQH.Abp.DataProtection;

[DependsOn(typeof(AbpObjectExtendingModule))]
public class AbpDataProtectionAbstractionsModule : AbpModule
{
}
