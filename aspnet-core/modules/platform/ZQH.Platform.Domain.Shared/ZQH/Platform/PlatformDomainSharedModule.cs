using ZQH.Platform.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Platform;

[DependsOn(
    typeof(AbpLocalizationModule),
    typeof(AbpMultiTenancyAbstractionsModule))]
public class PlatformDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PlatformDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<PlatformResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/ZQH.Platform/Localization/Resources");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Platform", typeof(PlatformResource));
        });
    }
}
