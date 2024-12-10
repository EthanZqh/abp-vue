﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace ZQH.Abp.MessageService;

[DependsOn(
    typeof(AbpMessageServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AbpMessageServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AbpMessageServiceApplicationContractsModule).Assembly,
            AbpMessageServiceConsts.RemoteServiceName
        );
    }
}
