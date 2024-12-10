using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ZQH.MicroService.Onboarding.EntityFrameworkCore;

public class OnboardingMigrationsDbContextFactory : IDesignTimeDbContextFactory<OnboardingMigrationsDbContext>
{
    public OnboardingMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString("Default");

        var builder = new DbContextOptionsBuilder<OnboardingMigrationsDbContext>()
               //.UseSqlServer(connectionString);
               .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new OnboardingMigrationsDbContext(builder!.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ZQH.MicroService.Onboarding.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
