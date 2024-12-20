using ZQH.Platform.Datas;
using ZQH.Platform.Layouts;
using ZQH.Platform.Menus;
using ZQH.Platform.Packages;
using ZQH.Platform.Portal;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using ZQH.Platform.DataItems;

namespace ZQH.Platform.EntityFrameworkCore;

[DependsOn(
    typeof(PlatformDomainModule),
    typeof(AbpEntityFrameworkCoreModule))]
public class PlatformEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<PlatformDbContext>(options =>
        {
            options.AddRepository<Data, EfCoreDataRepository>();
            options.AddRepository<Menu, EfCoreMenuRepository>();
            options.AddRepository<UserMenu, EfCoreUserMenuRepository>();
            options.AddRepository<RoleMenu, EfCoreRoleMenuRepository>();
            options.AddRepository<UserFavoriteMenu, EfCoreUserFavoriteMenuRepository>();
            options.AddRepository<Layout, EfCoreLayoutRepository>();
            options.AddRepository<Package, EfCorePackageRepository>();
            options.AddRepository<Enterprise, EfCoreEnterpriseRepository>();


            //新增
            options.AddRepository<DataItem, EfCoreDataItemRepository>();

            options.AddDefaultRepositories(includeAllEntities: true);
        });
    }
}
