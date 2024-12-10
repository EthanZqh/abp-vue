using System.Collections.Generic;

namespace ZQH.Abp.IM.Messages;

public interface IMessageSenderProviderManager
{
    List<IMessageSenderProvider> Providers { get; }
}
