using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.Saas.Tenants;
public class TenantUpdateDto : TenantCreateOrUpdateBase, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}