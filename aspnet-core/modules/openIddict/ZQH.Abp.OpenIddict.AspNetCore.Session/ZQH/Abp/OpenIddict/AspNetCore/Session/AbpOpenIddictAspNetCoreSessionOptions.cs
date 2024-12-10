using System.Collections.Generic;

namespace ZQH.Abp.OpenIddict.AspNetCore.Session;
public class AbpOpenIddictAspNetCoreSessionOptions
{
    public List<string> PersistentSessionGrantTypes { get; set; }
    public AbpOpenIddictAspNetCoreSessionOptions()
    {
        PersistentSessionGrantTypes = new List<string>();
    }
}
