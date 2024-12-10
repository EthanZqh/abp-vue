using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Identity;

public class OrganizationUnitGetUnaddedRoleByPagedDto : PagedAndSortedResultRequestDto
{

    public string Filter { get; set; }
}
