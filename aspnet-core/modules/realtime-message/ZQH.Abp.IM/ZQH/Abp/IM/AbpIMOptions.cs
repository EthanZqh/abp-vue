using ZQH.Abp.IM.Messages;
using Volo.Abp.Collections;

namespace ZQH.Abp.IM;

public class AbpIMOptions
{
    /// <summary>
    ///  消息发送者
    /// </summary>
    public ITypeList<IMessageSenderProvider> Providers { get; }

    public AbpIMOptions()
    {
        Providers = new TypeList<IMessageSenderProvider>();
    }
}
