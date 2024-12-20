using ZQH.Abp.Employees;
using ZQH.Abp.Identity.Dto.EmployeeDto;
using ZQH.Abp.Identity.Employees;
using ZQH.Abp.Saas.Tenants;
using ZQH.Platform.Datas;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace ZQH.Abp.Identity.Employees;
public class EmployeeAppService : IdentityAppServiceBase,IEmployeeAppService
{
    protected EmployeeManager EmployeeManager { get;}
    protected IEmployeeRepository EmployeeRepository { get; }
    protected ITenantRepository TenantRepository { get; }//测试多个数据库联合查询引入存储库

    protected IIdentityUserRepository UserRepository { get; }//
    protected IdentityUserManager UserManager { get; }//
    protected IOrganizationUnitRepository OrganizationUnitRepository { get; }
    protected IDataRepository DataRepository { get; }
    protected IDataItemRepository DataItemRepository { get; }
    public EmployeeAppService(EmployeeManager employeeManager, IEmployeeRepository employeeRepository, ITenantRepository tenantRepository, IIdentityUserRepository userRepository, IdentityUserManager userManager, IOrganizationUnitRepository organizationUnitRepository, IDataRepository dataRepository, IDataItemRepository dataItemRepository)
    //public EmployeeAppService(EmployeeManager employeeManager,IEmployeeRepository employeeRepository, IIdentityUserRepository userRepository, IOrganizationUnitRepository organizationUnitRepository, IDataItemRepository dataItemRepository)
    {
        EmployeeManager = employeeManager;
        EmployeeRepository = employeeRepository;
        TenantRepository = tenantRepository;
        UserRepository = userRepository;
        UserManager = userManager;
        OrganizationUnitRepository = organizationUnitRepository;
        DataRepository = dataRepository;
        DataItemRepository = dataItemRepository;
    }

    public virtual async Task<EmployeeDto> CreateAsync(EmployeeCreateDto input)
    {
        var employee = new Employee(
            GuidGenerator.Create(),
            input.EmployeeName,
            input.Sex,
            input.Birthday,
            input.Nation,
            input.NativePlace,
            input.PhoneNumber,
            input.Address,
            input.Position,
            CurrentTenant.Id,
            input.OrganizationUnitId
        )
        { CreationTime = Clock.Now };
        await EmployeeManager.CreateAsync(employee);
        //await CurrentUnitOfWork.SaveChangesAsync();
        //插入员工用户表数据
        if (input.UserNames.Length > 0)
        {
            foreach (var user in input.UserNames)
            {
                var userEntity = await UserManager.FindByNameAsync(user.ToUpper());
                employee.AddUser(userEntity.Id);
            }
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        return ObjectMapper.Map<Employee, EmployeeDto>(employee);
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await EmployeeRepository.FindByIdAsync(id);
        if (employee == null)
        {
            return;
        }
        await EmployeeRepository.RemoveAllUsersAsync(employee);
        await EmployeeRepository.DeleteAsync(id);
    }

    public Task<ListResultDto<EmployeeDto>> GetAllListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> GetAsync(Guid id)
    {
        var employees = await EmployeeRepository.FindAsync(id);

        return ObjectMapper.Map<Employee, EmployeeDto>(employees);
    }

    public async Task<PagedResultDto<EmployeeDto>> GetListAsync(EmployeeGetByPagedDto input)
    {
        var organizationUnits = await OrganizationUnitRepository.GetListAsync();
        var employees = await EmployeeRepository.GetListAsync();
        var dataDicItems = await DataItemRepository.GetListAsync();
        var joinedResult = (from employee in employees join organizationUnit in organizationUnits on employee.OrganizationUnitId equals organizationUnit.Id join dataDicItemSex in dataDicItems on employee.Sex equals dataDicItemSex.Name join dataDicItemNation in dataDicItems on employee.Nation equals dataDicItemNation.Name select new EmployeeDto { Id = employee.Id, EmployeeName = employee.EmployeeName, Sex = dataDicItemSex.DisplayName, Birthday = employee.Birthday, Nation = dataDicItemNation.DisplayName, NativePlace = employee.NativePlace, PhoneNumber = employee.PhoneNumber, Address = employee.Address, Position = employee.Position, TenantId = employee.TenantId, OrganizationUnitId = employee.OrganizationUnitId, OrganizationUnitName = organizationUnit.DisplayName, AvatarUrl = employee.AvatarUrl }).ToList();
        //var joinedResult = (from employee in employees join organizationUnit in organizationUnits on employee.OrganizationUnitId equals organizationUnit.Id join dataDicItemSex in  dataDicItems on employee.Sex equals dataDicItemSex.Name join dataDicItemNation in dataDicItems on  employee.Nation equals dataDicItemNation.Name join dataDicItemNativePlace in dataDicItems on employee.NativePlace equals dataDicItemNativePlace.Name  select new EmployeeDto { Id = employee.Id, EmployeeName = employee.EmployeeName, Sex = dataDicItemSex.DisplayName, Birthday = employee.Birthday, Nation = dataDicItemNation.DisplayName, NativePlace = dataDicItemNativePlace.DisplayName, PhoneNumber = employee.PhoneNumber, Address = employee.Address, Position = employee.Position, TenantId = employee.TenantId, OrganizationUnitId = employee.OrganizationUnitId, OrganizationUnitName = organizationUnit.DisplayName,AvatarUrl= employee.AvatarUrl }).ToList();
        var employeeCount = await EmployeeRepository.GetCountAsync(input.Filter);
        var url = "/api/api/files/static/public/p/";
        foreach (var employee in joinedResult)
        {
            employee.AvatarUrl = url + employee.AvatarUrl;
        }
        return new PagedResultDto<EmployeeDto>(employeeCount, joinedResult.AsReadOnly());

   





        //var employeeCount = await EmployeeRepository.GetCountAsync(input.Filter);
        //var employees = await EmployeeRepository
        //    .GetPagedListAsync(input.Filter, input.Sorting, input.SkipCount, input.MaxResultCount, true);
        //var url = "/api/api/files/static/public/p/";
        //foreach (var employee in employees)
        //{
        //    employee.AvatarUrl = url + employee.AvatarUrl;
        //}

        //return new PagedResultDto<EmployeeDto>(employeeCount,
        //    ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(employees));
    }

    public async Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto input)
    {
        var employee = await EmployeeRepository.GetAsync(id);
        employee.EmployeeName = input.EmployeeName;
        employee.Sex = input.Sex;
        employee.Birthday = input.Birthday;
        employee.Nation = input.Nation;
        employee.NativePlace = input.NativePlace;
        employee.Address = input.Address;
        employee.Position = input.Position;
        employee.PhoneNumber = input.PhoneNumber;
        employee.OrganizationUnitId = input.OrganizationUnitId;
        //插入员工用户表数据
        await EmployeeRepository.RemoveAllUsersAsync(employee);
        await EmployeeRepository.UpdateAsync(employee);
        if (input.UserNames.Length > 0)
        {
            foreach (var user in input.UserNames)
            {
                var userEntity = await UserManager.FindByNameAsync(user.ToUpper());
                employee.AddUser(userEntity.Id);
            }
            await CurrentUnitOfWork.SaveChangesAsync();
        }
        return ObjectMapper.Map<Employee, EmployeeDto>(employee);
    }

    public async Task ChangeAvatarAsync(Guid id, ChangeAvatarInput input)
    {
        var employee = await EmployeeRepository.GetAsync(id);
        employee.AvatarUrl = input.AvatarUrl;
        await EmployeeRepository.UpdateAsync(employee);
        await CurrentUnitOfWork.SaveChangesAsync();
    }

    public async Task<List<ResultDto>> PerformJoinedQueryAsync()
    {
        var tentants = await TenantRepository.GetListAsync();
        var employees = await EmployeeRepository.GetListAsync();
        var joinedResult = (from tenant in tentants join employee in employees on tenant.IsDeleted equals employee.IsDeleted select new ResultDto { TenantId = tenant.Id, TenantName = tenant.Name, EmployeeName = employee.EmployeeName, Sex = employee.Sex, IsActive = tenant.IsActive }).ToList();
        return joinedResult;
    }

    public async Task<ListResultDto<IdentityUserDto>> GetAssignableUsersAsync()
    {
        var userlist = await UserRepository.GetListAsync();
        //var employeeUserList = await EmployeeRepository.GetUserEmployeesAsync();

        //var result1 = (from m in userlist select m).ToList();
        //var result2 = (from m in employeeUserList select m).ToList();
        //var finalResult = (from m in result1 where !(from k in result2 select k.UserId).Contains(m.Id) select m).ToList();
        return new ListResultDto<IdentityUserDto>(
            ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(userlist));
    }

    public async Task<ListResultDto<IdentityUserDto>> GetUsersAsync(Guid id)
    {
        var users = await UserRepository.GetListAsync();
        var userEmployees = await EmployeeRepository.GetUserEmployeesAsync();
        var joinedResult = (from user in users join userEmployee in userEmployees on user.Id equals userEmployee.UserId where userEmployee.EmployeeId == id select new IdentityUser(user.Id, user.Name, user.Email)).ToList();

        return new ListResultDto<IdentityUserDto>(
            ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(joinedResult)
        );
    }

    public async Task RemoveOrganizationUnitsAsync(Guid id)
    {
        var employee = await EmployeeRepository.FindByIdAsync(id);
        employee.OrganizationUnitId = null;
        await EmployeeRepository.UpdateAsync(employee);
        await CurrentUnitOfWork.SaveChangesAsync();
    }
}
