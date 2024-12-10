using Volo.Abp.Domain.Entities;

namespace ZQH.Platform.Menus;

public class UserFavoriteMenuUpdateDto : UserFavoriteMenuCreateOrUpdateDto, IHasConcurrencyStamp
{

    public string ConcurrencyStamp { get; set; }
}
