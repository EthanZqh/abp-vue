using System.Threading.Tasks;

namespace ZQH.Abp.IM.Messages;

public interface IMessageSender
{
    Task<string> SendMessageAsync(ChatMessage chatMessage);
}
