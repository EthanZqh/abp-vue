using ZQH.Abp.BlobStoring.Nexus;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Modularity;

namespace ZQH.Abp.OssManagement.Nexus;

[DependsOn(
    typeof(AbpBlobStoringNexusModule),
    typeof(AbpOssManagementDomainModule))]
public class AbpOssManagementNexusModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddTransient<IOssContainerFactory, NexusOssContainerFactory>();

        context.Services.AddTransient<IOssObjectExpireor>(provider =>
            provider
                .GetRequiredService<IOssContainerFactory>()
                .Create()
                .As<NexusOssContainer>());
    }
}
