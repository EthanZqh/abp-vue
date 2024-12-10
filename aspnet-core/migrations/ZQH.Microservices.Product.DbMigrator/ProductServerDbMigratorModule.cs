using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using ZQH.Microservices.Product.EntityFrameworkCore;

namespace ZQH.Microservices.Product.DbMigrator;
[DependsOn(
    typeof(ProductMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public class ProductServerDbMigratorModule : AbpModule
{
}
