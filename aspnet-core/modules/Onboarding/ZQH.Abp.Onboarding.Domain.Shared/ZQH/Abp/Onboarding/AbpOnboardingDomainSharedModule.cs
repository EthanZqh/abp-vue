using Volo.Abp.Auditing;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;
using ZQH.Abp.Onboarding.Localization;

namespace ZQH.Abp.Onboarding;
[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpAuditingContractsModule))]
public class AbpOnboardingDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpOnboardingDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpOnboardingResource>()
                .AddVirtualJson("/ZQH/Abp/Onboarding/Localization/Resources");
        });
        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpOnboardingErrorCodes.Namespace, typeof(AbpOnboardingResource));
        });
    }
}
