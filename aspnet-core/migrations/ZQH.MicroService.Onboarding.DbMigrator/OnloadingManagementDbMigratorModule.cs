
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using ZQH.MicroService.Onboarding.EntityFrameworkCore;

namespace ZQH.MicroService.Onloading.DbMigrator;

[DependsOn(
    typeof(OnboardingMigrationsEntityFrameworkCoreModule),
    typeof(AbpAutofacModule)
    )]
public partial class OnloadingManagementDbMigratorModule : AbpModule
{
}
