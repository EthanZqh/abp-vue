using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace ZQH.Abp.OpenApi.IdentityServer;

[DependsOn(
    typeof(AbpOpenApiModule),
    typeof(AbpIdentityServerDomainModule))]
public class AbpOpenApiIdentityServerModule : AbpModule
{
}
