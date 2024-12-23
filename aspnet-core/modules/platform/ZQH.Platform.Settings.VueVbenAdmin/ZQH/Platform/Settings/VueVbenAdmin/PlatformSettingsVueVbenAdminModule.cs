﻿using ZQH.Platform.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Platform.Settings.VueVbenAdmin;

[DependsOn(
    typeof(PlatformDomainSharedModule),
    typeof(AbpMultiTenancyModule))]
public class PlatformSettingsVueVbenAdminModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PlatformSettingsVueVbenAdminModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PlatformResource>()
                .AddVirtualJson("/ZQH.Platform/Settings/VueVbenAdmin/Localization/Resources");
        });
    }
}
