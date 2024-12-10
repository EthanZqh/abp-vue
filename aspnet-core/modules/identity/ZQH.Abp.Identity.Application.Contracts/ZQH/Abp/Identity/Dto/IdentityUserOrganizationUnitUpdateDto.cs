using System;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.Identity;

public class IdentityUserOrganizationUnitUpdateDto
{
    [Required]
    public Guid[] OrganizationUnitIds { get; set; }
}
