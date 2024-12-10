using System;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Platform.Menus;
public class UserFavoriteMenuRemoveInput
{
    [Required]
    public Guid MenuId { get; set; }
}
