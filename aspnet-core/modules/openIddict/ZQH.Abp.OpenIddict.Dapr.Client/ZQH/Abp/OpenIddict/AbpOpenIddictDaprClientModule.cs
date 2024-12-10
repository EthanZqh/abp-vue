﻿using Microsoft.Extensions.DependencyInjection;
using ZQH.Abp.Dapr.Client;
using Volo.Abp.Modularity;

namespace ZQH.Abp.OpenIddict;

[DependsOn(
    typeof(AbpOpenIddictApplicationContractsModule),
    typeof(AbpDaprClientModule))]
public class AbpOpenIddictDaprClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticDaprClientProxies(
            typeof(AbpOpenIddictApplicationContractsModule).Assembly,
            OpenIddictRemoteServiceConsts.RemoteServiceName);
    }
}