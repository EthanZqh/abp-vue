using ZQH.Abp.LocalizationManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.MicroService.LocalizationManagement.EntityFrameworkCore;

[ConnectionStringName("LocalizationManagementDbMigrator")]
public class LocalizationManagementMigrationsDbContext : AbpDbContext<LocalizationManagementMigrationsDbContext>
{
    public LocalizationManagementMigrationsDbContext(DbContextOptions<LocalizationManagementMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureLocalization();
    }
}
