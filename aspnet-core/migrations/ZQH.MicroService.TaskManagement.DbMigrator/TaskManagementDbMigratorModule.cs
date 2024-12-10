using ZQH.MicroService.TaskManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ZQH.MicroService.TaskManagement.DbMigrator;

[DependsOn(
    typeof(TaskManagementMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public partial class TaskManagementDbMigratorModule : AbpModule
{
}
