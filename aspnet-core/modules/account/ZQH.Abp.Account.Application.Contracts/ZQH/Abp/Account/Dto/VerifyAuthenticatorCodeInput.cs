using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.Account;
public class VerifyAuthenticatorCodeInput
{
    [Required]
    [StringLength(6)]
    public string AuthenticatorCode { get; set; }
}
