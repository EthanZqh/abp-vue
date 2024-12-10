using System;

namespace ZQH.Abp.DataProtectionManagement;
public class OrganizationUnitEntityRuleDto : EntityRuleDtoBase
{
    public Guid OrgId { get; set; }
    public string OrgCode { get; set; }
}
