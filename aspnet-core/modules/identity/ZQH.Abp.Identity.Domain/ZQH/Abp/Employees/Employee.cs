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
public class Employee : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public virtual Guid? TenantId  { get;  set; }
    public virtual string EmployeeName { get; set; }
    public virtual string Sex { get; set; }
    public virtual DateTime? Birthday { get; set; }
    public virtual string Nation { get; set; }
    public virtual string NativePlace { get; set; }
    public virtual string PhoneNumber { get; set; }
    public virtual string Address { get; set; }
    public virtual string Position { get; set; }
    public virtual Guid? OrganizationUnitId { get; set; }
    //public virtual OrganizationUnit OrganizationUnit { get; set; }

    public virtual string AvatarUrl { get; set; }

    public virtual ICollection<UserEmployee> Users { get; protected set; }
    public Employee() { 
        Users = new Collection<UserEmployee>();
    }
    public Employee(
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
        EmployeeName = employeeName;
        TenantId = tenantid;
        Sex= sex;
        Birthday= birthday;
        Nation= nation;
        NativePlace = nativePlace;
        PhoneNumber= phoneNumber;
        Address= address; 
        Position= possiton;
        CreationTime = new DateTime();
        OrganizationUnitId= organizationUnitId;
        Users = new Collection<UserEmployee>();

    }
    public virtual void SetEmployeeOrganizationUnit(Guid organizationUnitId)
    {
        OrganizationUnitId = organizationUnitId;
    }
    public virtual void SetEmployeeAvatarUrl(string avatarUrl)
    {
        AvatarUrl = avatarUrl;
    }
    public Employee AddUser(Guid userId)
    {
        if (!IsInUser(userId))
        {
            Users.Add(
                  new UserEmployee(
                      Guid.NewGuid(),
                      userId,
                      Id,
                      TenantId
                  )
              );
        }
        return this;

    }

    public bool RemoveUser(Guid userId)
    {
        Check.NotNull(userId, nameof(userId));

        if (IsInUser(userId))
        {
            Users.RemoveAll(r => r.UserId == userId);
            return true;
        }
        return false;
    }

    public virtual bool IsInUser(Guid userId)
    {
        return Users.Any(
            ou => ou.UserId == userId
        );
    }



}
