using ZQH.Abp.Identity.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Validation;

namespace ZQH.Abp.Identity.Dto.EmployeeDto;
public class EmployeeUpdateDto : EmployeeCreateOrUpdateDtoBase
{

    public DateTime? Birthday { get; set; }

    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxAvatarUrlLength))]
    public string AvatarUrl { get; set; }
}
