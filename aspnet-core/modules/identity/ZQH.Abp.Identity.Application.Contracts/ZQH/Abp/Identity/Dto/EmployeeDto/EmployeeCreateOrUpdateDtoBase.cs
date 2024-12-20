using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;
using ZQH.Abp.Identity.Employees;

namespace ZQH.Abp.Identity.Dto.EmployeeDto;
public abstract class EmployeeCreateOrUpdateDtoBase
{
    [Required]
    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxNameLength))]
    public string EmployeeName { get; set; }
    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxSexLength))]
    public string Sex { get; set; }

    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxNameLength))]
    public string Nation { get; set; }
    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxNameLength))]
    public string NativePlace { get; set; }
    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxNameLength))]
    public string PhoneNumber { get; set; }
    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxNameLength))]
    public string Address { get; set; }
    [DynamicStringLength(typeof(EmployeeConsts), nameof(EmployeeConsts.MaxNameLength))]
    public string Position { get; set; }
    public Guid? OrganizationUnitId { get; set; }
    [CanBeNull]
    public string[] UserNames { get; set; }



}
