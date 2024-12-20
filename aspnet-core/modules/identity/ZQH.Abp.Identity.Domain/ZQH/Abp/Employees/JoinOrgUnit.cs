using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace ZQH.Abp.Employees;
/// <summary>
/// 员工
/// </summary>
public class JoinOrgUnit : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public virtual Guid? TenantId  { get;  set; }
    public virtual string Name { get; set; }
    public virtual Guid? OrganizationUnitId { get; set; }
    public JoinOrgUnit() { }
    public JoinOrgUnit(
        Guid id,
        [NotNull] string employeeName,
        string sex,
        DateTime? birthday,
        string nation,
        string nativePlace,
        string phoneNumber,
        string address,
        string possiton, 
        Guid? tenantid = null,
        Guid? organizationUnitId=null) 
        :base(id)
    {
        Check.NotNull(employeeName, nameof(employeeName));
        Name = employeeName;
        TenantId = tenantid;
        CreationTime = new DateTime();
        OrganizationUnitId= organizationUnitId;
    }








}
