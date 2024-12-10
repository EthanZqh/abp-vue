using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using ZQH.Platform.EntityFrameworkCore;

namespace ZQH.MicroService.Onboarding.EntityFrameworkCore;

[ConnectionStringName("LocalizationManagementDbMigrator")]
public class OnboardingMigrationsDbContext : AbpDbContext<OnboardingMigrationsDbContext>
{
    public OnboardingMigrationsDbContext(DbContextOptions<OnboardingMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureOnboarding();
    }
}
