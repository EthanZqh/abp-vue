using ZQH.Abp.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace ZQH.Abp.Identity.EntityFrameworkCore.Employees;
public class EfCoreEmployeeRepository: EfCoreRepository<EmployeeDbContext, Employee, Guid>,IEmployeeRepository
{
    public EfCoreEmployeeRepository(IDbContextProvider<EmployeeDbContext> dbContextProvider) :base(dbContextProvider)
    { 
    
    
    }

    public async Task<Employee> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<Employee> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .Where(x => x.EmployeeName == name)
            .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<int> GetCountAsync(string filter = "", CancellationToken cancellationToken = default)
    {
        //var dbSet = await GetDbSetAsync();
        //return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), x
        //    => x.EmployeeName.Contains(filter) || x.Nation.Contains(filter))
        //    .CountAsync(GetCancellationToken(cancellationToken));
        return await (await GetQueryableAsync())
       .WhereIf(
           !filter.IsNullOrWhiteSpace(),
           u =>
               u.EmployeeName.Contains(filter)
       ).CountAsync(cancellationToken: cancellationToken);
    }

    public async Task<int> GetEmployeeCountAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.WhereIf(!id.ToString().IsNullOrEmpty(), x
            => x.OrganizationUnitId==id)
            .CountAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<Employee>> GetListAsync(Guid id, string sorting = "EmployeeName", int skipCount = 0, int maxResultCount = 10, CancellationToken cancellationToken = default)
    {
        sorting ??= nameof(Employee.EmployeeName);
        return await(await GetDbSetAsync())
            .WhereIf(!id.ToString().IsNullOrEmpty(),employee =>
                    employee.OrganizationUnitId==id)
            .OrderBy(sorting)
            .PageBy(skipCount, maxResultCount)
            .AsNoTracking()
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<Employee>> GetPagedListAsync(string filter = "", string sorting = "EmployeeName", int skipCount = 0, int maxResultCount = 10, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        sorting ??= nameof(Employee.EmployeeName);
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(!filter.IsNullOrWhiteSpace(), x =>
                  x.EmployeeName.Contains(filter) || x.Nation.Contains(filter) ||
                  x.NativePlace.Contains(filter) || x.Address.Contains(filter))
            .OrderBy(sorting)
            .PageBy(skipCount, maxResultCount)
            .AsNoTracking()
            .ToListAsync(GetCancellationToken(cancellationToken));

        //var dbContext = await GetDbContextAsync();
        //var organizationUnitDbSet = dbContext.Set<OrganizationUnit>();
        //var employeeDbSet = dbContext.Set<Employee>()
        //     .IncludeDetails(includeDetails);
        //employeeDbSet = employeeDbSet
        //   .WhereIf(!filter.IsNullOrWhiteSpace(), u => u.EmployeeName.Contains(filter))
        //   .OrderBy(sorting.IsNullOrEmpty() ? nameof(Employee.EmployeeName) : sorting);

        //var combinedResult = await (from employee in employeeDbSet
        //                            join organizationUnit in organizationUnitDbSet on employee.OrganizationUnitId equals organizationUnit.Id
        //                            into eg
        //                            from e in eg.DefaultIfEmpty()
        //                            select new
        //                            {
        //                                Employee = employee,
        //                                OrganizationUnit = e,
        //                            })
        //                 .Skip(skipCount)
        //                 .Take(maxResultCount)
        //                 .ToListAsync(GetCancellationToken(cancellationToken));

        //return combinedResult.Select(s =>
        //{
        //    //s.Employee.or = s.OrganizationUnit;
        //    return s.Employee;
        //}).ToList();



    }

    public async Task<List<UserEmployee>> GetUserEmployeesAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();

        var query = from employeeUser in dbContext.Set<UserEmployee>()  select employeeUser;
                    //join user in dbContext.Users.IncludeDetails(includeDetails) on employeeUser.UserId equals user.Id
                    //where employeeUser.UserId == id
                    //select user;

        return await query.ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<UserEmployee>> GetUserEmployeesAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();
        var query = from employeeUser in dbContext.Set<UserEmployee>() where employeeUser.EmployeeId==id select employeeUser;
        return await query.ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task RemoveAllUsersAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        var dbContext = await GetDbContextAsync();
        var employeesQuery = await dbContext.Set<UserEmployee>()
            .Where(q => q.EmployeeId == employee.Id)
            .ToListAsync(GetCancellationToken(cancellationToken));

        dbContext.Set<UserEmployee>().RemoveRange(employeesQuery);
    }
}
