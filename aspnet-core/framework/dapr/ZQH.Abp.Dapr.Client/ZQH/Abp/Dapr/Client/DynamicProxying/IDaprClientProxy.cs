﻿namespace ZQH.Abp.Dapr.Client.DynamicProxying;

public interface IDaprClientProxy<out TRemoteService>
{
    TRemoteService Service { get; }
}
