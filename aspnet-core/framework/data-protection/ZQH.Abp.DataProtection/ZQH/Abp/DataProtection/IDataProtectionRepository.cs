using System.Linq;
using System.Threading.Tasks;

namespace ZQH.Abp.DataProtection;
public interface IDataProtectionRepository<TEntity> : IDataProtectedEnabled
{
    Task<IQueryable<TEntity>> GetQueryableAsync();
}
