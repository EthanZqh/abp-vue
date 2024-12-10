using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.TaskManagement;

public class BackgroundJobInfoUpdateDto : BackgroundJobInfoCreateOrUpdateDto, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
