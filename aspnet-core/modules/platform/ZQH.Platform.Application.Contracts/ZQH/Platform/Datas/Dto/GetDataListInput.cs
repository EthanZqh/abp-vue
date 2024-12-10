using Volo.Abp.Application.Dtos;

namespace ZQH.Platform.Datas;

public class GetDataListInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
