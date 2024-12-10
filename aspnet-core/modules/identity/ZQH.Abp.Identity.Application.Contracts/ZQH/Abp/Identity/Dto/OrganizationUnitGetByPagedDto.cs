using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Identity;

public class OrganizationUnitGetByPagedDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
