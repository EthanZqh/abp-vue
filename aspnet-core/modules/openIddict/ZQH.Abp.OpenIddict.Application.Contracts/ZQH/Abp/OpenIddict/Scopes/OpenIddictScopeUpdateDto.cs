using System;
using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.OpenIddict.Scopes;

[Serializable]
public class OpenIddictScopeUpdateDto : OpenIddictScopeCreateOrUpdateDto, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
