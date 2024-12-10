using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using ZQH.Abp.Onboarding.Localization;

namespace ZQH.Abp.Onboarding;
[DependsOn(
    typeof(AbpOnboardingDomainSharedModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationContractsModule))]
public class AbpOnboardingApplicationContractsModule:AbpModule
{
    //public override void ConfigureServices(ServiceConfigurationContext context)
    //{
    //    Configure<AbpVirtualFileSystemOptions>(options =>
    //    {
    //        options.FileSets.AddEmbedded<AbpOnboardingApplicationContractsModule>();
    //    });

    //    Configure<AbpLocalizationOptions>(options =>
    //    {
    //        options.Resources
    //            .Get<AbpOnboardingResource>()
    //            .AddVirtualJson("/ZQH/Abp/Onboarding/Localization/Resources");
    //    });
    //}

}
