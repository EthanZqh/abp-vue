using ZQH.Linq.Dynamic.Queryable;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Dynamic.Queryable;

public class GetListByDynamicQueryableInput : PagedAndSortedResultRequestDto
{
    [Required]
    public DynamicQueryable Queryable { get; set; }
}
