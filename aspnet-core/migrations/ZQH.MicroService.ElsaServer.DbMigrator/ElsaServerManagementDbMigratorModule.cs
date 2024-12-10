using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using ZQH.MicroService.ElsaServer.EntityFrameworkCore;

namespace ZQH.MicroService.ElsaServer.DbMigrator;
[DependsOn(
    typeof(ElsaServerMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public class ElsaServerManagementDbMigratorModule:AbpModule
{

}
