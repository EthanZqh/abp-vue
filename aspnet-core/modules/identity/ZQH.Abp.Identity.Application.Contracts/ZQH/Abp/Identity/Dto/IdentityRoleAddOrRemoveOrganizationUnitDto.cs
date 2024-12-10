using System;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.Identity;

public class IdentityRoleAddOrRemoveOrganizationUnitDto
{
    [Required]
    public Guid[] OrganizationUnitIds { get; set; }
}
