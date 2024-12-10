using Volo.Abp.Application;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Authorization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.Auditing;

[DependsOn(
    typeof(AbpFeaturesModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpDddApplicationContractsModule))]
public class AbpAuditingApplicationContractsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAuditingApplicationContractsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AuditLoggingResource>()
                .AddVirtualJson("/ZQH.Abp/Auditing/Localization/Resources");
        });
    }
}
