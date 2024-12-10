using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.IdentityServer.ApiResources;

public class ApiResourceGetByPagedInputDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
