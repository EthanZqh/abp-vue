using ZQH.Abp.Identity.Dto.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace ZQH.Abp.Identity.Employees;
public interface IEmployeeAppService: ICrudAppService<EmployeeDto,Guid, EmployeeGetByPagedDto,EmployeeCreateDto,EmployeeUpdateDto>
{
    Task<ListResultDto<EmployeeDto>> GetAllListAsync();
    Task ChangeAvatarAsync(Guid id, ChangeAvatarInput input);
    //测试多个数据库联合查询接口
    Task<List<ResultDto>> PerformJoinedQueryAsync();
    Task<ListResultDto<IdentityUserDto>> GetAssignableUsersAsync();

    Task<ListResultDto<IdentityUserDto>> GetUsersAsync(Guid id);
    Task RemoveOrganizationUnitsAsync(Guid id);

}
