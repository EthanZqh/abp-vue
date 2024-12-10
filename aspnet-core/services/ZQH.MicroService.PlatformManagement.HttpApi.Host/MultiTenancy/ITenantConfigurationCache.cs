using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace ZQH.MicroService.PlatformManagement.MultiTenancy;

public interface ITenantConfigurationCache
{
    Task<List<TenantConfiguration>> GetTenantsAsync();
}
