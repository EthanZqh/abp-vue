using ZQH.Abp.IdentityServer.SmsValidator;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.IdentityServer;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.IdentityServer;

[DependsOn(typeof(AbpIdentityServerDomainModule))]
public class AbpIdentityServerSmsValidatorModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IIdentityServerBuilder>(builder =>
        {
            builder.AddExtensionGrantValidator<SmsTokenGrantValidator>();
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpIdentityServerSmsValidatorModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AbpIdentityServerResource>()
                .AddVirtualJson("/ZQH.Abp/IdentityServer/Localization/SmsValidator");
        });
    }
}
