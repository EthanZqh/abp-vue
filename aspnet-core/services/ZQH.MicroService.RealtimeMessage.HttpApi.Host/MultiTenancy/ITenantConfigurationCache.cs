using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace ZQH.MicroService.RealtimeMessage.MultiTenancy;

public interface ITenantConfigurationCache
{
    Task RefreshAsync();

    Task<List<TenantConfiguration>> GetTenantsAsync();
}
