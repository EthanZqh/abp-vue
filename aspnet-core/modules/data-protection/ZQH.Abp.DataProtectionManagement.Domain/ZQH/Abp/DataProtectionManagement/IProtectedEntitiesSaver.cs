using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.DataProtectionManagement;
public interface IProtectedEntitiesSaver
{
    Task SaveAsync(CancellationToken cancellationToken = default);
}
