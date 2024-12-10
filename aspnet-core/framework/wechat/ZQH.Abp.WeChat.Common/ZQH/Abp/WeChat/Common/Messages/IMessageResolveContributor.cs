using System.Threading.Tasks;

namespace ZQH.Abp.WeChat.Common.Messages;
public interface IMessageResolveContributor
{
    string Name { get; }

    Task ResolveAsync(IMessageResolveContext context);
}
