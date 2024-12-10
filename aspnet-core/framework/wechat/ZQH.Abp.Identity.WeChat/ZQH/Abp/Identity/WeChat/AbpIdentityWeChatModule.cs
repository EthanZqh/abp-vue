using ZQH.Abp.WeChat;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Identity.WeChat;

[DependsOn(
    typeof(AbpWeChatModule),
    typeof(AbpIdentityDomainModule))]
public class AbpIdentityWeChatModule : AbpModule
{
}
