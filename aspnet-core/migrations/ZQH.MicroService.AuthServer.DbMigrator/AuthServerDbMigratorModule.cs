using ZQH.MicroService.AuthServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ZQH.MicroService.AuthServer.DbMigrator;

[DependsOn(
    typeof(AuthServerMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public partial class AuthServerDbMigratorModule : AbpModule
{
}
