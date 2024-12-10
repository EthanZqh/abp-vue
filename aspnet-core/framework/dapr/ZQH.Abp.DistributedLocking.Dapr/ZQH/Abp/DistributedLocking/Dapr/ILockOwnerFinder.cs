using System.Threading.Tasks;

namespace ZQH.Abp.DistributedLocking.Dapr;

public interface ILockOwnerFinder
{
    Task<string> FindAsync();
}
