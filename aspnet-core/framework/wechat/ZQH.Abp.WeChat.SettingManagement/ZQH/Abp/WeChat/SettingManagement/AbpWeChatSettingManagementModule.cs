using ZQH.Abp.WeChat.Localization;
using ZQH.Abp.WeChat.MiniProgram;
using ZQH.Abp.WeChat.Official;
using ZQH.Abp.WeChat.Work;
using ZQH.Abp.WeChat.Work.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.WeChat.SettingManagement;

[DependsOn(
    typeof(AbpWeChatOfficialModule),
    typeof(AbpWeChatMiniProgramModule),
    typeof(AbpWeChatWorkModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AbpWeChatSettingManagementModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpWeChatSettingManagementModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpWeChatSettingManagementModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<WeChatResource>()
                .AddVirtualJson("/ZQH.Abp/WeChat/SettingManagement/Localization/Resources");
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<WeChatResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource),
                    typeof(WeChatWorkResource)
                );
        });
    }
}
