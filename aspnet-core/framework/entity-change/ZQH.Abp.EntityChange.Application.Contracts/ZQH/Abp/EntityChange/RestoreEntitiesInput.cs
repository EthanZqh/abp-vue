using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.EntityChange;

public class RestoreEntitiesInput
{
    [Required]
    public List<RestoreEntityInput> Entities { get; set; }
}
