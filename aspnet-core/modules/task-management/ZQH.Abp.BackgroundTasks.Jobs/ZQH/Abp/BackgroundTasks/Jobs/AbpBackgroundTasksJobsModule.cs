﻿using ZQH.Abp.BackgroundTasks.Localization;
using ZQH.Abp.Dapr.Client;
using ZQH.Abp.Dapr.Client.ClientProxying;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.Http.Client;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Sms;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.BackgroundTasks.Jobs;

[DependsOn(typeof(AbpEmailingModule))]
[DependsOn(typeof(AbpSmsModule))]
[DependsOn(typeof(AbpHttpClientModule))]
[DependsOn(typeof(AbpDaprClientModule))]
[DependsOn(typeof(AbpBackgroundTasksAbstractionsModule))]
public class AbpBackgroundTasksJobsModule : AbpModule
{
    protected const string DontWrapResultField = "_AbpDontWrapResult";

    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<AbpHttpClientBuilderOptions>(options =>
        {
            options.ProxyClientBuildActions.Add((remoteService, builder) =>
            {
                builder.ConfigureHttpClient(client =>
                {
                    // 后台作业一般都是内部调用, 不需要包装结果
                    client.DefaultRequestHeaders.TryAddWithoutValidation(DontWrapResultField, "true");
                });
            });
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpBackgroundTasksJobsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BackgroundTasksResource>()
                .AddVirtualJson("/ZQH.Abp/BackgroundTasks/Jobs/Localization/Resources");
        });

        Configure<AbpDaprClientProxyOptions>(options =>
        {
            options.ProxyRequestActions.Add((remoteService, request) =>
            {
                // 后台作业一般都是内部调用, 不需要包装结果
                request.Headers.TryAddWithoutValidation(DontWrapResultField, "true");
            });
        });

        context.Services.AddHttpClient(BackgroundTasksConsts.DefaultHttpClient);
    }
}
