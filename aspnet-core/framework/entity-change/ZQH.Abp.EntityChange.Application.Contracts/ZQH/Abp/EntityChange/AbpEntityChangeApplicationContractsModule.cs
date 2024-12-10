﻿using ZQH.Abp.EntityChange.Localization;
using Volo.Abp.Application;
using Volo.Abp.Auditing;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.EntityChange;

[DependsOn(
    typeof(AbpAuditingModule),
    typeof(AbpDddApplicationContractsModule))]
public class AbpEntityChangeApplicationContractsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpEntityChangeApplicationContractsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpEntityChangeResource>()
                .AddVirtualJson("/ZQH.Abp/EntityChange/Localization/Resources");
        });
    }
}
