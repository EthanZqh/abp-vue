﻿using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.Identity;

[DependsOn(typeof(Volo.Abp.Identity.AbpIdentityDomainSharedModule))]
public class AbpIdentityDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpIdentityDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<IdentityResource>()
                .AddVirtualJson("/ZQH/Abp/Identity/Localization");
        });
    }
}
