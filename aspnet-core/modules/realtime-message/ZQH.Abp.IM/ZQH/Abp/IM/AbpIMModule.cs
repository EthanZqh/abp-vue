using ZQH.Abp.IM.Localization;
using ZQH.Abp.RealTime;
using ZQH.Abp.IdGenerator;
using Volo.Abp.EventBus;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.IM;

[DependsOn(
    typeof(AbpEventBusModule),
    typeof(AbpRealTimeModule),
    typeof(AbpLocalizationModule),
    typeof(AbpIdGeneratorModule))]
public class AbpIMModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpIMModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpIMResource>()
                .AddVirtualJson("/ZQH/Abp/IM/Localization/Resources");
        });
    }
}
