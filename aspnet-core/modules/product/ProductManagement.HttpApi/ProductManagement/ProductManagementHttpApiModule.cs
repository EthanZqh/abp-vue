using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ProductManagement
{
    [DependsOn(
        typeof(ProductManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ProductManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProductManagementHttpApiModule).Assembly);
            });
        }
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProductManagementHttpApiModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ProductApiResource>()
                    .AddVirtualJson("/ProductManagement/Localization/ApplicationContracts");
            });
        }
    }
}
