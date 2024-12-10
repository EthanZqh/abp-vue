using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.MessageService.Groups;

public class GroupSearchInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
