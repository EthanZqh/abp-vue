using Dapr.Actors;
using ZQH.Abp.Wrapper;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Dapr.Actors.AspNetCore.Wrapper;

[DependsOn(
    typeof(AbpDaprActorsAspNetCoreModule),
    typeof(AbpWrapperModule))]
public class AbpDaprActorsAspNetCoreWrapperModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpWrapperOptions>(options =>
        {
            options.IgnoredInterfaces.TryAdd<IActor>();
        });
    }
}