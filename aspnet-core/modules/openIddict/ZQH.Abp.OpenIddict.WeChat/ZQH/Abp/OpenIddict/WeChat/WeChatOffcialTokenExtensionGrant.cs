﻿using ZQH.Abp.WeChat.Official;
using ZQH.Abp.WeChat.Official.Features;
using ZQH.Abp.WeChat.OpenId;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Features;
using Volo.Abp.OpenIddict.ExtensionGrantTypes;
using Volo.Abp.OpenIddict.Localization;

namespace ZQH.Abp.OpenIddict.WeChat;
public class WeChatOffcialTokenExtensionGrant : WeChatTokenExtensionGrant
{
    public override string Name => WeChatTokenExtensionGrantConsts.OfficialGrantType;

    public override string LoginProvider => AbpWeChatOfficialConsts.ProviderName;

    public override string AuthenticationMethod => AbpWeChatOfficialConsts.AuthenticationMethod;

    protected async override Task CheckFeatureAsync(ExtensionGrantContext context)
    {
        var featureChecker = GetRequiredService<IFeatureChecker>(context);

        if (!await featureChecker.IsEnabledAsync(WeChatOfficialFeatures.EnableAuthorization))
        {
            var localizer = GetRequiredService<IStringLocalizer<AbpOpenIddictResource>>(context);

            throw new AbpException(localizer["OfficialAuthorizationDisabledMessage"]);
        }
    }

    protected async override Task<WeChatOpenId> FindOpenIdAsync(ExtensionGrantContext context, string code)
    {
        var weChatOpenIdFinder = GetRequiredService<IWeChatOpenIdFinder>(context);
        var optionsFactory = GetRequiredService<AbpWeChatOfficialOptionsFactory>(context);

        var options = await optionsFactory.CreateAsync();

        return await weChatOpenIdFinder.FindAsync(code, options.AppId, options.AppSecret);
    }
}
