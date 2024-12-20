using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace ZQH.Abp.Employees;
public class EmployeeManager: DomainService
{
    protected IEmployeeRepository EmployeeRepository { get; }
    protected IStringLocalizer<IdentityResource> Localizer { get; }
    protected ICancellationTokenProvider CancellationTokenProvider { get; }
    public EmployeeManager(IEmployeeRepository employeeRepository, IStringLocalizer<IdentityResource> localizer, ICancellationTokenProvider cancellationTokenProvider)
    {
        EmployeeRepository = employeeRepository;
        Localizer = localizer;
        CancellationTokenProvider = cancellationTokenProvider;
    }
    [UnitOfWork]
    public virtual async Task CreateAsync(Employee employee)
    {
        var existingEmployee = await EmployeeRepository.FirstOrDefaultAsync(p => p.EmployeeName == employee.EmployeeName && p.OrganizationUnitId == employee.OrganizationUnitId && p.Birthday == employee.Birthday);
        //var existingEmployee = await EmployeeRepository.FirstOrDefaultAsync(p => p.EmployeeName == employee.EmployeeName && p.OrganizationUnitId==employee.OrganizationUnitId && p.Birthday==employee.Birthday);
        if (existingEmployee != null)
        {
            throw new EmployeeNameAlreadyExistsException(existingEmployee.EmployeeName);
        }
        await EmployeeRepository.InsertAsync(employee).ConfigureAwait(continueOnCapturedContext: false);
    }
}
