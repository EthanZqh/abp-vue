using ZQH.Abp.Data.DbMigrator;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZQH.Abp.Onboarding.EntityFrameworkCore;

namespace ZQH.MicroService.Onboarding.EntityFrameworkCore;

[DependsOn(
    typeof(AbpOnboardingEntityFrameworkCoreModule),
    typeof(AbpDataDbMigratorModule)
    )]
public class OnboardingMigrationsEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<OnboardingMigrationsDbContext>();

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
        });
    }
}
