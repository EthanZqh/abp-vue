using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.OssManagement;

public class GetOssContainersInput : PagedAndSortedResultRequestDto
{
    public string Prefix { get; set; }
    public string Marker { get; set; }
}
