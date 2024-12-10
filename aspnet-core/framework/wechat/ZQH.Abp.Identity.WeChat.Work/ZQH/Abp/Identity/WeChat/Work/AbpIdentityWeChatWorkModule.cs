using ZQH.Abp.WeChat.Work;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Identity.WeChat.Work;

[DependsOn(
    typeof(AbpWeChatWorkModule),
    typeof(AbpIdentityDomainModule))]
public class AbpIdentityWeChatWorkModule : AbpModule
{

}
