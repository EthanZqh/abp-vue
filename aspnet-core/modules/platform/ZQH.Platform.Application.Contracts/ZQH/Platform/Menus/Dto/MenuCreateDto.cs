using System;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Platform.Menus;

public class MenuCreateDto : MenuCreateOrUpdateDto
{
    [Required]
    public Guid LayoutId { get; set; }
}
