using Volo.Abp.Domain.Entities;

namespace ZQH.Platform.Packages;

public class PackageUpdateDto : PackageCreateOrUpdateDto, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
