using System;
using System.Collections.Generic;
using System.Text;

namespace ZQH.Abp.Identity.Dto.EmployeeDto;
public class ResultDto
{
    public Guid TenantId { get; set; }
    public string TenantName { get; set; }
    public bool IsActive { get; set; }
    public string EmployeeName { get; set; }
    public string Sex { get; set; }


}
