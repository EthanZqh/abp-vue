using Volo.Abp.Collections;

namespace ZQH.Abp.IdentityServer;
public class AbpIdentityServerEventOptions
{
    public ITypeList<IAbpIdentityServerEventServiceHandler> EventServiceHandlers { get; }
    public AbpIdentityServerEventOptions()
    {
        EventServiceHandlers = new TypeList<IAbpIdentityServerEventServiceHandler>();
    }
}
