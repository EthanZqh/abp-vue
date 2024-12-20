using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Validation;
using ZQH.Abp.Identity.Employees;

namespace ZQH.Abp.Identity.Dto.EmployeeDto;
public class EmployeeCreateDto : EmployeeCreateOrUpdateDtoBase
{
    //[DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxBirthdayLength))]
    public DateTime? Birthday { get; set; }

    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxAvatarUrlLength))]
    public string AvatarUrl { get; set; }
}
