using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.Saas.Editions;

public class EditionUpdateDto : EditionCreateOrUpdateBase, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
