using Volo.Abp.Modularity;

namespace ZQH.Abp.OssManagement.FileSystem.ImageSharp;

[DependsOn(typeof(AbpOssManagementFileSystemModule))]
public class AbpOssManagementFileSystemImageSharpModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<FileSystemOssOptions>(options =>
        {
            options.AddProcesser(new ImageSharpProcesserContributor());
        });
    }
}
