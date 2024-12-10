using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.OpenApi;

public interface IClientChecker
{
    Task<bool> IsGrantAsync(string clientId, CancellationToken cancellationToken = default);
}
