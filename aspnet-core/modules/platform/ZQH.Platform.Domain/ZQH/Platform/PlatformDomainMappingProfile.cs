using AutoMapper;
using ZQH.Platform.Layouts;
using ZQH.Platform.Menus;
using ZQH.Platform.Packages;

namespace ZQH.Platform;

public class PlatformDomainMappingProfile : Profile
{
    public PlatformDomainMappingProfile()
    {
        CreateMap<Layout, LayoutEto>();

        CreateMap<Menu, MenuEto>();
        CreateMap<UserMenu, UserMenuEto>();
        CreateMap<RoleMenu, RoleMenuEto>();

        CreateMap<Package, PackageEto>();
    }
}
