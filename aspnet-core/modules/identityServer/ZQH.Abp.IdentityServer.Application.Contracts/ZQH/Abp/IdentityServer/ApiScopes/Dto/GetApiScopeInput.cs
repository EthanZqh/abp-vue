using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.IdentityServer.ApiScopes;

public class GetApiScopeInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
