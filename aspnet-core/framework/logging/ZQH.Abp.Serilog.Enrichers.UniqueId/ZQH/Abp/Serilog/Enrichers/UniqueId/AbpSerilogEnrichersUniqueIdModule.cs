using ZQH.Abp.IdGenerator;
using ZQH.Abp.IdGenerator.Snowflake;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Serilog.Enrichers.UniqueId;

[DependsOn(typeof(AbpIdGeneratorModule))]
public class AbpSerilogEnrichersUniqueIdModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var options = context.Services.ExecutePreConfiguredActions<AbpSerilogEnrichersUniqueIdOptions>();
        UniqueIdEnricher.DistributedIdGenerator = SnowflakeIdGenerator.Create(options.SnowflakeIdOptions);
    }
}
