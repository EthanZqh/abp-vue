using AutoMapper;
using ZQH.Abp.Employees;
using ZQH.Abp.Identity.Dto.EmployeeDto;
using ZQH.Abp.Saas.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;

namespace ZQH.Abp.Identity.Employees;
public class EmployeeDomainMappingProfile : Profile
{
    public EmployeeDomainMappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().Ignore(o => o.OrganizationUnitName);
            ;
        //CreateMap<Employee, EmployeeDto>()
        // .ForMember(dto => dto.OrganizationUnitId, map =>
        // {
        //     map.MapFrom((employee, dto) =>
        //     {
        //         return employee.OrganizationUnit?.Id;
        //     });
        // })
        // .ForMember(dto => dto.OrganizationUnitName, map =>
        // {
        //     map.MapFrom((employee, dto) =>
        //     {
        //         return employee.OrganizationUnit?.DisplayName;
        //     });
        // })
        // .MapExtraProperties();
        //CreateMap<Employee, EmployeeResultDto>();
    }

}