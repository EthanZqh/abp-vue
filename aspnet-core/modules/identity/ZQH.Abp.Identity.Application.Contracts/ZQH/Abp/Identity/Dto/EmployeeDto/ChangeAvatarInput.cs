using ZQH.Abp.Identity.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace ZQH.Abp.Identity.Dto.EmployeeDto;
public class ChangeAvatarInput
{
    [DynamicMaxLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxAvatarUrlLength))]
    public string AvatarUrl { get; set; }
}
