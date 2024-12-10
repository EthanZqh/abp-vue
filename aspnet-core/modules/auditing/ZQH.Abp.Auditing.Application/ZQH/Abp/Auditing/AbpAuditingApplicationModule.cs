using ZQH.Abp.AuditLogging;
using ZQH.Abp.Logging;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Auditing;

[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(AbpLoggingModule),
    typeof(AbpAuditLoggingModule),
    typeof(AbpAuditingApplicationContractsModule))]
public class AbpAuditingApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpAuditingApplicationModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<AbpAuditingMapperProfile>(validate: true);
        });
    }
}
