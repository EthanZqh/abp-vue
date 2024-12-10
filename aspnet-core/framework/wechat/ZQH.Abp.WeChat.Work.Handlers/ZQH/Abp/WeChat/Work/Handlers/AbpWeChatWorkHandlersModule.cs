using ZQH.Abp.WeChat.Work.Common;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace ZQH.Abp.WeChat.Work.Handlers;

[DependsOn(typeof(AbpEventBusModule))]
[DependsOn(typeof(AbpWeChatWorkCommonModule))]
public class AbpWeChatWorkHandlersModule : AbpModule
{
}
