using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace ZQH.Abp.Identity.Dto.EmployeeDto;
public class EmployeeDto : ExtensibleFullAuditedEntityDto<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public string EmployeeName { get; set; }
    public string Sex { get; set; }
    public DateTime? Birthday { get; set; }
    public string Nation { get; set; }
    public string NativePlace { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Position { get; set; }
    public Guid? OrganizationUnitId { get; set; }
    public string OrganizationUnitName { get; set; }
    public string AvatarUrl { get; set; }
}
