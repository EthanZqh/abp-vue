//using ZQH.Abp.Data.DbMigrator;
//using ZQH.Abp.Identity.EntityFrameworkCore;
//using ZQH.Abp.Saas.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZQH.Abp.Data.DbMigrator;
using ZQH.Abp.Identity.EntityFrameworkCore;
using ZQH.Abp.Saas.EntityFrameworkCore;

namespace ZQH.Microservices.Product.EntityFrameworkCore;

[DependsOn(
    typeof(AbpSaasEntityFrameworkCoreModule),
    //typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(ProductManagementEntityFrameworkCoreModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpDataDbMigratorModule)
    )]
public class ProductMigrationsEntityFrameworkCoreModule:AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ProductMigrationsDbContext>();

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL();
            //options.UseSqlServer();
        });
    }

}

