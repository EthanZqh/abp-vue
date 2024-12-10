
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ProductManagement.EntityFrameworkCore
{
    public class ProductRepository : EfCoreRepository<ProductManagementDbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(
       IDbContextProvider<ProductManagementDbContext> dbContextProvider)
       : base(dbContextProvider)
        {
        }


      public virtual async Task<int> GetCountAsync(
      string filter = "",
      CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(), product =>
                        product.Code.Contains(filter) || product.Name.Contains(filter))
                .CountAsync(GetCancellationToken(cancellationToken));
        }


        public  async Task<List<Product>> GetListAsync(string filter = "", string sorting = nameof(Product.Code),int skipCount = 0, int maxResultCount = 10, CancellationToken cancellationToken = default)
        {
            
            sorting ??= nameof(Product.Code);
            return await(await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(), product =>
                        product.Code.Contains(filter) || product.Name.Contains(filter))
                .OrderBy(sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

    }
}
