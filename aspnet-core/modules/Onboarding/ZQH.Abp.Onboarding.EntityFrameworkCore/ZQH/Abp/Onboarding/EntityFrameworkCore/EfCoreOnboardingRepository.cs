using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ZQH.Abp.Onboarding.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZQH.Abp.Onboarding.EntityFrameworkCore;
public class EfCoreOnboardingRepository : EfCoreRepository<IOnboardingDbContext, OnboardingTask,Guid>, IOnboardingRepository
{
    public EfCoreOnboardingRepository(IDbContextProvider<IOnboardingDbContext> dbContextProvider)
    : base(dbContextProvider)
    {

    }

    public async Task<OnboardingTask> FindById(Guid id)
    {
        //var tenantDbSet = GetDbSetAsync();

        //return tenantDbSet.
        //    .OrderBy(t => t.Id)
        //    .FirstOrDefault(t => t.Id == id);

        //var dbSet = await GetDbSetAsync();
        //return await dbSet.FirstOrDefault(t => t.Id == id);


        //var tenantDbSet = DbContext.Set<Tenant>()
        //.IncludeDetails(includeDetails);

        //if (includeDetails)
        //{
        //    var editionDbSet = DbContext.Set<Edition>();
        //    var queryable = from tenant in tenantDbSet
        //                    join edition in editionDbSet on tenant.EditionId equals edition.Id into eg
        //                    from e in eg.DefaultIfEmpty()
        //                    where tenant.Name.Equals(name)
        //                    orderby tenant.Id
        //                    select new
        //                    {
        //                        Tenant = tenant,
        //                        Edition = e,
        //                    };
        //    var result = queryable
        //        .FirstOrDefault();
        //    if (result != null && result.Tenant != null)
        //    {
        //        result.Tenant.Edition = result.Edition;
        //    }

        //    return result?.Tenant;
        //}

        //return tenantDbSet
        //    .OrderBy(t => t.Id)
        //    .FirstOrDefault(t => t.Name == name);

        var dbSet = await GetDbSetAsync();
        return await dbSet
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

    }

    public async Task<int> GetCountAsync(string filter = "", CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(!filter.IsNullOrWhiteSpace(), x =>
                x.EmployeeName.Contains(filter) || x.Description.Contains(filter) ||
                x.Name.Contains(filter) || x.Users.Contains(filter))
            .Where(x=>x.IsCompleted==false)
            .CountAsync(GetCancellationToken(cancellationToken));
    }

    public async virtual Task<List<OnboardingTask>> GetListAsync(string sorting = null, int maxResultCount = 10, int skipCount = 0, string filter = null, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        if (sorting.IsNullOrWhiteSpace())
        {
            sorting = nameof(OnboardingTask.EmployeeName);
        }
        return await (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(), x => x.EmployeeName.Contains(filter))
            .OrderBy(sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<OnboardingTask>> GetPagedListAsync(string filter = "", string sorting = "CreationTime", bool includeDetails = false, int skipCount = 0, int maxResultCount = 10, CancellationToken cancellationToken = default)
    {
        if (sorting.IsNullOrWhiteSpace())
        {
            sorting = nameof(OnboardingTask.CreationTime);
        }

        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(!filter.IsNullOrWhiteSpace(), x =>
                x.EmployeeName.Contains(filter) || x.Description.Contains(filter) ||
                x.Name.Contains(filter) || x.Users.Contains(filter))
            .Where(x => x.IsCompleted == false)
            .OrderBy(sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }
}
