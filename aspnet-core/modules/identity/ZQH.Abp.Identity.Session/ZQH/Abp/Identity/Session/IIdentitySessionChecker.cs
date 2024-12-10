using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.Identity.Session;
public interface IIdentitySessionChecker
{
    Task<bool> ValidateSessionAsync(string sessionId, CancellationToken cancellationToken = default);
}
