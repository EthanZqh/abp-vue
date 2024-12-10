using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.OpenApi;
public interface IIpAddressChecker
{
    Task<bool> IsGrantAsync(string ipAddress, CancellationToken cancellationToken = default);
}
