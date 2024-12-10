using ZQH.Abp.OssManagement;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace ZQH.Abp.BlobStoring.OssManagement;

[DependsOn(typeof(AbpBlobStoringModule))]
[DependsOn(typeof(AbpOssManagementHttpApiClientModule))]
public class AbpBlobStoringOssManagementModule : AbpModule
{
}
