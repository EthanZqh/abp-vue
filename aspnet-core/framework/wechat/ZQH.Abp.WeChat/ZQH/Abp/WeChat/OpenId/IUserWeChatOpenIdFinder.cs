using System;
using System.Threading.Tasks;

namespace ZQH.Abp.WeChat.OpenId;

public interface IUserWeChatOpenIdFinder
{
    Task<string> FindByUserIdAsync(Guid userId, string provider);

    Task<string> FindByUserNameAsync(string userName, string provider);
}
