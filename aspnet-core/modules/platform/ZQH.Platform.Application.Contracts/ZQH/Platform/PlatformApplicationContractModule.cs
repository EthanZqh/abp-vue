using ZQH.Platform.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Platform;

[DependsOn(typeof(PlatformDomainSharedModule))]
public class PlatformApplicationContractModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PlatformApplicationContractModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PlatformResource>()
                .AddVirtualJson("/ZQH.Platform/Localization/ApplicationContracts");
        });
    }
}
