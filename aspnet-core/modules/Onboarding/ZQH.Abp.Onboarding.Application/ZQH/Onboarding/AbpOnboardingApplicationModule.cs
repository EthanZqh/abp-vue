using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Onboarding;
[DependsOn(
    typeof(AbpOnboardingDomainModule),
    typeof(AbpOnboardingApplicationContractsModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpDddApplicationModule))]
public class AbpOnboardingApplicationModule:AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpOnboardingApplicationModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<OnboardingApplicationMappingProfile>(validate: true);
        });
    }
}
