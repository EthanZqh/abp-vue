using System;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.Account;

public class GetTwoFactorProvidersInput
{
    [Required]
    public Guid UserId { get; set; }
}
