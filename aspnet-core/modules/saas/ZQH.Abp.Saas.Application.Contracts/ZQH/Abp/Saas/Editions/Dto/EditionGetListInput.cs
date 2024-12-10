using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Saas.Editions;

public class EditionGetListInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
