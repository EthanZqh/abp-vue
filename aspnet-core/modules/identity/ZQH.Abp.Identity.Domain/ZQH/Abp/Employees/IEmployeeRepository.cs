using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace ZQH.Abp.Employees;
public interface IEmployeeRepository : IBasicRepository<Employee, Guid>, IRepository<Employee, Guid>
{
    Task<Employee> FindByNameAsync(
        string name,
        CancellationToken cancellationToken = default);
    Task<Employee> FindByIdAsync(
      Guid id,
      CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(
    string filter = "",
    CancellationToken cancellationToken = default);
    Task<List<Employee>> GetPagedListAsync(
        string filter = "",
        string sorting = nameof(Employee.EmployeeName),
        int skipCount = 0,
        int maxResultCount = 10,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);
    Task<List<UserEmployee>> GetUserEmployeesAsync(
    bool includeDetails = false,
    CancellationToken cancellationToken = default
);

    Task<List<UserEmployee>> GetUserEmployeesAsync(Guid id,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
        );
    Task RemoveAllUsersAsync(Employee employee, CancellationToken cancellationToken = default);

    Task<int> GetEmployeeCountAsync(
         Guid id,
         CancellationToken cancellationToken = default);

    Task<List<Employee>> GetListAsync(
     Guid id,
     string sorting = nameof(Employee.EmployeeName),
     int skipCount = 0,
     int maxResultCount = 10,
     CancellationToken cancellationToken = default);

    //Task<List<UserEmployee>> GetUserEmployeesByEmployeeIdAndUserIdAsync(Guid employeeId,Guid userId,
    //bool includeDetails = false,
    //CancellationToken cancellationToken = default
    //);

}
