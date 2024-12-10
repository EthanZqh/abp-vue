using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZQH.Abp.Onboarding.Entities;

namespace ZQH.Abp.Onboarding.EntityFrameworkCore;
[DependsOn(
    typeof(AbpOnboardingDomainModule),
    typeof(AbpEntityFrameworkCoreModule))]
public class AbpOnboardingEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<OnboardingDbContext>(options =>
        {
            options.AddRepository<OnboardingTask, EfCoreOnboardingRepository>();


            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}
