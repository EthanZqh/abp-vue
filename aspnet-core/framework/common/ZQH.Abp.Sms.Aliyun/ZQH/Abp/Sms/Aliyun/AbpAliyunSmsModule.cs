﻿using ZQH.Abp.Aliyun;
using ZQH.Abp.Aliyun.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Sms;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.Sms.Aliyun;

[DependsOn(
    typeof(AbpSmsModule),
    typeof(AbpAliyunModule))]
public class AbpAliyunSmsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAliyunSmsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                   .Get<AliyunResource>()
                   .AddVirtualJson("/ZQH.Abp/Sms/Aliyun/Localization/Resources");
        });
    }
}
