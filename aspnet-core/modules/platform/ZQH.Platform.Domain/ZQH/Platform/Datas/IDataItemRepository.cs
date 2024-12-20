using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace ZQH.Platform.Datas;
public interface IDataItemRepository : IBasicRepository<DataItem, Guid>
{
}
