using System.Xml.Linq;
using Volo.Abp.DependencyInjection;

namespace ZQH.Abp.WeChat.Common.Messages;
public interface IMessageResolveContext : IServiceProviderAccessor
{
    string Origin { get; }
    XDocument MessageData { get; }
    bool Handled { get; set; }
    WeChatMessage Message { get; set; }
}
