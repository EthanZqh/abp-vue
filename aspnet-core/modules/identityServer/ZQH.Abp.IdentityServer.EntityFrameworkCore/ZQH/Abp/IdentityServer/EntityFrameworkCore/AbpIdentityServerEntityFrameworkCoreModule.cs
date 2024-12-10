using Volo.Abp.Modularity;

namespace ZQH.Abp.IdentityServer.EntityFrameworkCore;

[DependsOn(typeof(ZQH.Abp.IdentityServer.AbpIdentityServerDomainModule))]
[DependsOn(typeof(Volo.Abp.IdentityServer.EntityFrameworkCore.AbpIdentityServerEntityFrameworkCoreModule))]
public class AbpIdentityServerEntityFrameworkCoreModule : AbpModule
{
}
