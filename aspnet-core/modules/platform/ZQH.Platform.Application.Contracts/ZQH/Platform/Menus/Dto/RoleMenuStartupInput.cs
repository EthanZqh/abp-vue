using System.ComponentModel.DataAnnotations;

namespace ZQH.Platform.Menus;

public class RoleMenuStartupInput
{
    [Required]
    [StringLength(80)]
    public string RoleName { get; set; }
}
