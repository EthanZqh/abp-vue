using ZQH.Platform.Datas;
using ZQH.Platform.Layouts;
using ZQH.Platform.Menus;
using ZQH.Platform.Packages;
using ZQH.Platform.Portal;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.Platform.EntityFrameworkCore;

[ConnectionStringName(PlatformDbProperties.ConnectionStringName)]
public interface IPlatformDbContext : IEfCoreDbContext
{
    DbSet<Menu> Menus { get; }
    DbSet<Layout> Layouts { get; }
    DbSet<RoleMenu> RoleMenus { get; }
    DbSet<UserMenu> UserMenus { get; }
    DbSet<UserFavoriteMenu> UserFavoriteMenus { get; }
    DbSet<Data> Datas { get; }
    DbSet<DataItem> DataItems { get; }
    DbSet<Package> Packages { get; }
    DbSet<PackageBlob> PackageBlobs { get; }
    DbSet<Enterprise> Enterprises { get; }
}
