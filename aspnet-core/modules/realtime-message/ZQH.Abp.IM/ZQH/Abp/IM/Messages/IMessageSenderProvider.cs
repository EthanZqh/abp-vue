using System.Threading.Tasks;

namespace ZQH.Abp.IM.Messages;

public interface IMessageSenderProvider
{
    string Name { get; }
    Task SendMessageAsync(ChatMessage chatMessage);
}
