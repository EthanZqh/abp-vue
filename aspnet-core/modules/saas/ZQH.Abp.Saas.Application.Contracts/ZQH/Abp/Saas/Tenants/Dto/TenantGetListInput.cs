using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Saas.Tenants;

public class TenantGetListInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}