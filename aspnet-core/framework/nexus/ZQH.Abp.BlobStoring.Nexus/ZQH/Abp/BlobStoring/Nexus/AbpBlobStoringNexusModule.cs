using ZQH.Abp.Sonatype.Nexus;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace ZQH.Abp.BlobStoring.Nexus;

[DependsOn(
    typeof(AbpBlobStoringModule),
    typeof(AbpSonatypeNexusModule))]
public class AbpBlobStoringNexusModule : AbpModule
{
}
