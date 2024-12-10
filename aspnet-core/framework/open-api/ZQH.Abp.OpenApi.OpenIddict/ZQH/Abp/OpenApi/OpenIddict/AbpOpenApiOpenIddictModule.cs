using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;

namespace ZQH.Abp.OpenApi.OpenIddict;

[DependsOn(
    typeof(AbpOpenApiModule),
    typeof(AbpOpenIddictDomainModule))]
public class AbpOpenApiOpenIddictModule : AbpModule
{
}
