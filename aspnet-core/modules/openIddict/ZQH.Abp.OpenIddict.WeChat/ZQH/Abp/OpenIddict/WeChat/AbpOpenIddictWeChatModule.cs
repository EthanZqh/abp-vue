using ZQH.Abp.Identity.WeChat;
using ZQH.Abp.WeChat.MiniProgram;
using ZQH.Abp.WeChat.Official;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.OpenIddict.ExtensionGrantTypes;
using Volo.Abp.OpenIddict.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.OpenIddict.WeChat;

[DependsOn(
    typeof(AbpWeChatOfficialModule),
    typeof(AbpWeChatMiniProgramModule),
    typeof(AbpIdentityWeChatModule),
    typeof(AbpOpenIddictAspNetCoreModule))]
public class AbpOpenIddictWeChatModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<OpenIddictServerBuilder>(builder =>
        {
            builder
                .AllowWeChatFlow()
                .RegisterWeChatScopes()
                .RegisterWeChatClaims();
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpOpenIddictExtensionGrantsOptions>(options =>
        {
            options.Grants.TryAdd(
                WeChatTokenExtensionGrantConsts.OfficialGrantType,
                new WeChatOffcialTokenExtensionGrant());

            options.Grants.TryAdd(
                WeChatTokenExtensionGrantConsts.MiniProgramGrantType,
                new WeChatMiniProgramTokenExtensionGrant());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpOpenIddictWeChatModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AbpOpenIddictResource>()
                .AddVirtualJson("/ZQH.Abp/OpenIddict/WeChat/Localization/Resources");
        });
    }
}