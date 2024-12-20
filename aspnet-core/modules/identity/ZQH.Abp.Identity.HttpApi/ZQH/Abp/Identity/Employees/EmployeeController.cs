using ZQH.Abp.Identity.Dto.EmployeeDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Asp.Versioning;

namespace ZQH.Abp.Identity.Employees;

[RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
[Area("identity")]
[ControllerName("Employees")]
[Route("api/identity/employees")]
public class EmployeeController : AbpController, IEmployeeAppService
{
    protected IEmployeeAppService EmployeeAppService { get; }
    public EmployeeController(IEmployeeAppService employeeAppService)
    {
        EmployeeAppService = employeeAppService;
    }

    [HttpPost]
    public async Task<EmployeeDto> CreateAsync(EmployeeCreateDto input)
    {
        return await EmployeeAppService.CreateAsync(input);
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task DeleteAsync(Guid id)
    {
         await EmployeeAppService.DeleteAsync(id);
    }
    [HttpGet]
    [Route("all")]
    public Task<ListResultDto<EmployeeDto>> GetAllListAsync()
    {
        throw new NotImplementedException();
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<EmployeeDto> GetAsync(Guid id)
    {
        return await EmployeeAppService.GetAsync(id);
    }
    [HttpGet]
    public async Task<PagedResultDto<EmployeeDto>> GetListAsync(EmployeeGetByPagedDto input)
    {
        return await EmployeeAppService.GetListAsync(input);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto input)
    {
        return await EmployeeAppService.UpdateAsync(id, input);
    }

    [HttpPost]
    [Route("{id}/change-avatar")]
    public async virtual Task ChangeAvatarAsync(Guid id, ChangeAvatarInput input)
    {
        await EmployeeAppService.ChangeAvatarAsync(id, input);
    }
    [HttpGet]
    [Route("JoinedQueryDB")]
    public async Task<List<ResultDto>> PerformJoinedQueryAsync()
    {
        return await EmployeeAppService.PerformJoinedQueryAsync();
    }
    [HttpGet]
    [Route("assignable-users")]
    public Task<ListResultDto<IdentityUserDto>> GetAssignableUsersAsync()
    {
        return EmployeeAppService.GetAssignableUsersAsync();
    }
    [HttpGet]
    [Route("{id}/users")]
    public virtual Task<ListResultDto<IdentityUserDto>> GetUsersAsync(Guid id)
    {
        return EmployeeAppService.GetUsersAsync(id);
    }

    [HttpDelete]
    [Route("{id}/organization-units")]
    public async virtual Task RemoveOrganizationUnitsAsync(Guid id)
    {
        await EmployeeAppService.RemoveOrganizationUnitsAsync(id);
    }
}
