using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement
{
    public interface IProductRepository : IBasicRepository<Product, Guid>
    {

        Task<int> GetCountAsync(
           string filter = "",
           CancellationToken cancellationToken = default);

        Task<List<Product>> GetListAsync(
         string filter = "",
         string sorting = nameof(Product.Code),
         int skipCount = 0,
         int maxResultCount = 10,
         CancellationToken cancellationToken = default);



    }
   
}
