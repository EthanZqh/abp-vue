using ZQH.Abp.OpenApi.ConfigurationStore;
using ZQH.Abp.OpenApi.Localization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Security;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.OpenApi;

[DependsOn(
    typeof(AbpSecurityModule),
    typeof(AbpLocalizationModule))]
public class AbpOpenApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        var openApiConfig = configuration.GetSection("OpenApi");
        Configure<AbpOpenApiOptions>(openApiConfig);
        Configure<AbpDefaultAppKeyStoreOptions>(openApiConfig);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpOpenApiModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<OpenApiResource>()
                .AddVirtualJson("/ZQH.Abp/OpenApi/Localization/Resources");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpOpenApiConsts.KeyPrefix, typeof(OpenApiResource));
        });
    }
}
