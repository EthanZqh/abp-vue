using ZQH.Abp.Saas.Editions;
using ZQH.Abp.Saas.Tenants;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace ZQH.Abp.Saas.EntityFrameworkCore;

[IgnoreMultiTenancy]
[ConnectionStringName(AbpSaasDbProperties.ConnectionStringName)]
public interface ISaasDbContext : IEfCoreDbContext
{
    DbSet<Edition> Editions { get; }
    DbSet<Tenant> Tenants { get; }
    DbSet<TenantConnectionString> TenantConnectionStrings { get; }
}
