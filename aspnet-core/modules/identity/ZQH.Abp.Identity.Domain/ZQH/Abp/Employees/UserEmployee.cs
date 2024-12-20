using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace ZQH.Abp.Employees;
public class UserEmployee : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public virtual Guid? TenantId { get; set; }
    public virtual Guid UserId { get; set; }
    public virtual Guid EmployeeId { get; set; }
    public UserEmployee() { }
    public UserEmployee(Guid id, Guid userId,Guid employeeId, Guid? tenantid = null) :base(id) {
        TenantId = tenantid;
        UserId = userId;
        EmployeeId = employeeId;
    }
    public override object[] GetKeys()
    {
        return new object[] { UserId, EmployeeId };
    }

}
