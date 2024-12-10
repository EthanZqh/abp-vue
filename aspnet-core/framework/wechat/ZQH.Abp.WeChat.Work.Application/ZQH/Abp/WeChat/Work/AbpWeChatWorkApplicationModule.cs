using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace ZQH.Abp.WeChat.Work;

[DependsOn(
    typeof(AbpWeChatWorkApplicationContractsModule),
    typeof(AbpWeChatWorkModule),
    typeof(AbpDddApplicationModule))]
public class AbpWeChatWorkApplicationModule : AbpModule
{

}
