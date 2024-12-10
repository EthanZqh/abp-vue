using AutoMapper;
using ZQH.Platform.Datas;
using ZQH.Platform.Layouts;
using ZQH.Platform.Menus;
using ZQH.Platform.Packages;

namespace ZQH.Platform;

public class PlatformApplicationMappingProfile : Profile
{
    public PlatformApplicationMappingProfile()
    {
        CreateMap<PackageBlob, PackageBlobDto>();
        CreateMap<Package, PackageDto>();

        CreateMap<DataItem, DataItemDto>();
        CreateMap<Data, DataDto>();
        CreateMap<Menu, MenuDto>()
            .ForMember(dto => dto.Meta, map => map.MapFrom(src => src.ExtraProperties))
            .ForMember(dto => dto.Startup, map => map.Ignore());
        CreateMap<Layout, LayoutDto>()
            .ForMember(dto => dto.Meta, map => map.MapFrom(src => src.ExtraProperties));
        CreateMap<UserFavoriteMenu, UserFavoriteMenuDto>();
    }
}
