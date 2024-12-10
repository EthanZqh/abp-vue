using ZQH.Abp.Dapr.Actors.DynamicProxying;
using System;
using System.Collections.Generic;

namespace ZQH.Abp.Dapr.Actors;

public class AbpDaprActorProxyOptions
{
    public Dictionary<Type, DynamicDaprActorProxyConfig> ActorProxies { get; set; }

    public AbpDaprActorProxyOptions()
    {
        ActorProxies = new Dictionary<Type, DynamicDaprActorProxyConfig>();
    }
}
