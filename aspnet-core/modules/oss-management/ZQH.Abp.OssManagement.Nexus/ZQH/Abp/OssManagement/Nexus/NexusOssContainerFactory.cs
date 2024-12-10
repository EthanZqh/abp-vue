using ZQH.Abp.BlobStoring.Nexus;
using ZQH.Abp.Sonatype.Nexus.Assets;
using ZQH.Abp.Sonatype.Nexus.Components;
using ZQH.Abp.Sonatype.Nexus.Search;
using ZQH.Abp.Sonatype.Nexus.Services.CoreUI;
using Volo.Abp.BlobStoring;
using Volo.Abp.MultiTenancy;

namespace ZQH.Abp.OssManagement.Nexus;
internal class NexusOssContainerFactory : IOssContainerFactory
{
    protected ICoreUiServiceProxy CoreUiServiceProxy { get; }
    protected INexusAssetManager NexusAssetManager { get; }
    protected INexusComponentManager NexusComponentManager { get; }
    protected INexusLookupService NexusLookupService { get; }
    protected ICurrentTenant CurrentTenant { get; }
    protected IBlobRawPathCalculator BlobRawPathCalculator { get; }
    protected IBlobContainerConfigurationProvider ConfigurationProvider { get; }

    public NexusOssContainerFactory(
        ICoreUiServiceProxy coreUiServiceProxy,
        INexusAssetManager nexusAssetManager,
        INexusComponentManager nexusComponentManager,
        INexusLookupService nexusLookupService,
        ICurrentTenant currentTenant,
        IBlobRawPathCalculator blobRawPathCalculator,
        IBlobContainerConfigurationProvider configurationProvider)
    {
        CoreUiServiceProxy = coreUiServiceProxy;
        NexusAssetManager = nexusAssetManager;
        NexusComponentManager = nexusComponentManager;
        NexusLookupService = nexusLookupService;
        CurrentTenant = currentTenant;
        BlobRawPathCalculator = blobRawPathCalculator;
        ConfigurationProvider = configurationProvider;
    }

    public IOssContainer Create()
    {
        return new NexusOssContainer(
            CoreUiServiceProxy,
            NexusAssetManager,
            NexusComponentManager,
            NexusLookupService,
            CurrentTenant,
            BlobRawPathCalculator,
            ConfigurationProvider);
    }
}
