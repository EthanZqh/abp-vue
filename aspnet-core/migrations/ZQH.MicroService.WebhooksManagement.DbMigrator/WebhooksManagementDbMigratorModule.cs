using ZQH.MicroService.WebhooksManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ZQH.MicroService.WebhooksManagement.DbMigrator;

[DependsOn(
    typeof(WebhooksManagementMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public partial class WebhooksManagementDbMigratorModule : AbpModule
{
}
