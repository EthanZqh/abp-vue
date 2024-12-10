using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.IdentityServer.IdentityResources;

public class IdentityResourceGetByPagedDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
