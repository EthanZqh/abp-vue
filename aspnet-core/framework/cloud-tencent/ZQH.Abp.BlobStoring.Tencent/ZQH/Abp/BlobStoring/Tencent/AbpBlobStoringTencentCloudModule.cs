using ZQH.Abp.Tencent;
using ZQH.Abp.Tencent.Localization;
using Volo.Abp.BlobStoring;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.BlobStoring.Tencent;

[DependsOn(
    typeof(AbpBlobStoringModule),
    typeof(AbpTencentCloudModule))]
public class AbpBlobStoringTencentCloudModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpBlobStoringTencentCloudModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TencentCloudResource>()
                .AddVirtualJson("/ZQH.Abp/BlobStoring/Tencent/Localization");
        });
    }
}