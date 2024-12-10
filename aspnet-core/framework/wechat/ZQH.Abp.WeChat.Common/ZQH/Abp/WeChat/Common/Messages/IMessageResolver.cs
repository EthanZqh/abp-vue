using System.Threading.Tasks;

namespace ZQH.Abp.WeChat.Common.Messages;
public interface IMessageResolver
{
    Task<MessageResolveResult> ResolveMessageAsync(MessageResolveData messageData);
}
