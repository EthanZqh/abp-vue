using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using ZQH.Abp.Onboarding.Localization;

namespace ZQH.Abp.Onboarding;
[DependsOn(
    typeof(AbpAspNetCoreMvcModule),
    //typeof(AbpDynamicQueryableHttpApiModule),
    typeof(AbpOnboardingApplicationContractsModule))]
public class AbpOnboardingHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpOnboardingHttpApiModule).Assembly);
        });

        PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(
                    typeof(AbpOnboardingResource),
                    typeof(AbpOnboardingApplicationContractsModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources.Get<AbpOnboardingResource>()
                .AddBaseTypes(typeof(AbpValidationResource));
        });
    }








}
