using ZQH.Platform.Routes;
using Volo.Abp.EventBus;

namespace ZQH.Platform.Menus;

[EventName("platform.menus.menu")]
public class MenuEto : RouteEto
{
    public string Framework { get; set; }
}
