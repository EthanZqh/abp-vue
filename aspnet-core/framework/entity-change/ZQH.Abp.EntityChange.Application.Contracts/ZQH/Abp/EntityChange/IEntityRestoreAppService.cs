using System.Threading.Tasks;

namespace ZQH.Abp.EntityChange;

public interface IEntityRestoreAppService : IEntityChangeAppService
{
    Task RestoreEntityAsync(RestoreEntityInput input);

    Task RestoreEntitesAsync(RestoreEntitiesInput input);
}
