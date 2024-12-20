using ZQH.Platform.Datas;
using ZQH.Platform.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.Platform.DataItems;
public class EfCoreDataItemRepository : EfCoreRepository<PlatformDbContext, DataItem, Guid>, IDataItemRepository
{
    public EfCoreDataItemRepository(
    IDbContextProvider<PlatformDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
