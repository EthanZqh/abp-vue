using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.CachingManagement;

public class CacheKeyInput
{
    [Required]
    public string Key { get; set; }
}
