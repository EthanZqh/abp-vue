using ZQH.Abp.Wrapper;
using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;
using Volo.Abp.Timing;

namespace ZQH.Abp.OpenApi.Authorization
{
    [DependsOn(
        typeof(AbpWrapperModule),
        typeof(AbpTimingModule),
        typeof(AbpOpenApiModule),
        typeof(AbpAspNetCoreModule))]
    public class AbpOpenApiAuthorizationModule : AbpModule
    {
    }
}
