using System.Threading.Tasks;

namespace ZQH.Abp.Account.Emailing;

public interface IAccountEmailVerifySender
{
    Task SendMailLoginVerifyCodeAsync(
        string code,
        string userName,
        string emailAddress);
}
