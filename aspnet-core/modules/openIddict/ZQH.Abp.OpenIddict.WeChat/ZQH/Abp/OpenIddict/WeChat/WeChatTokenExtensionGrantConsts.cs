using ZQH.Abp.WeChat;
using ZQH.Abp.WeChat.MiniProgram;
using ZQH.Abp.WeChat.Official;

namespace ZQH.Abp.OpenIddict.WeChat;

public static class WeChatTokenExtensionGrantConsts
{
    public static string MiniProgramGrantType => AbpWeChatMiniProgramConsts.GrantType;
    public static string OfficialGrantType => AbpWeChatOfficialConsts.GrantType;
    public static string ProfileKey => AbpWeChatGlobalConsts.ProfileKey;
}
