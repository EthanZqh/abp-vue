using Elsa.EntityFrameworkCore.Modules.Management;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZQH.Abp.Data.DbMigrator;

namespace Elsa.EntityFrameworkCore.MySql;
[DependsOn(
    //typeof(AbpOnboardingEntityFrameworkCoreModule),
    typeof(AbpDataDbMigratorModule)
    )]
public class ElsaServerMigrationsEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ManagementElsaDbContext>();

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
        });
    }
}
