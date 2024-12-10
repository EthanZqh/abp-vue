using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Identity.Session.AspNetCore;

[DependsOn(typeof(AbpAspNetCoreModule))]
[DependsOn(typeof(AbpIdentitySessionModule))]
public class AbpIdentitySessionAspNetCoreModule : AbpModule
{
}
