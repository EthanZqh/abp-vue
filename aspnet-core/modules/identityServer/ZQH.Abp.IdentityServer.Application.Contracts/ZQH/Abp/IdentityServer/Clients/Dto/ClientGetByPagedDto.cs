using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.IdentityServer.Clients;

public class ClientGetByPagedDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
