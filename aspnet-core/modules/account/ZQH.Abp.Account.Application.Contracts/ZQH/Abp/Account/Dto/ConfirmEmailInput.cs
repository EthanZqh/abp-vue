using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.Account;

public class ConfirmEmailInput
{
    [Required]
    public string ConfirmToken { get; set; }
}
