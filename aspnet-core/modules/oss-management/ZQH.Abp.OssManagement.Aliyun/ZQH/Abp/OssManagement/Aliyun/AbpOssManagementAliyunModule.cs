using ZQH.Abp.BlobStoring.Aliyun;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Modularity;

namespace ZQH.Abp.OssManagement.Aliyun;

[DependsOn(
    typeof(AbpBlobStoringAliyunModule),
    typeof(AbpOssManagementDomainModule))]
public class AbpOssManagementAliyunModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddTransient<IOssContainerFactory, AliyunOssContainerFactory>();

        context.Services.AddTransient<IOssObjectExpireor>(provider =>
            provider
                .GetRequiredService<IOssContainerFactory>()
                .Create()
                .As<AliyunOssContainer>());
    }
}
