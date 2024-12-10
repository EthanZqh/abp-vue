using ZQH.Platform.Routes;
using Volo.Abp.Validation;

namespace ZQH.Platform.Menus;
public class UserFavoriteMenuGetListInput
{
    [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
    public string Framework { get; set; }
}
