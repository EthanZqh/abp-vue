using ZQH.Abp.Data.DbMigrator;
using ZQH.MicroService.RealtimeMessage.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ZQH.MicroService.RealtimeMessage.DbMigrator;

[DependsOn(
    typeof(RealtimeMessageMigrationsEntityFrameworkCoreModule),
    typeof(AbpDataDbMigratorModule),
    typeof(AbpAutofacModule)
    )]
public partial class RealtimeMessageDbMigratorModule : AbpModule
{
}
