using System.Threading.Tasks;

namespace ZQH.Abp.WeChat.Common.Messages.Handlers;
public interface IEventHandleContributor<TMessage> where TMessage : WeChatEventMessage
{
    Task HandleAsync(MessageHandleContext<TMessage> context);
}
