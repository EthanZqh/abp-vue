using ZQH.Abp.MessageService.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.MessageService;

[DependsOn(typeof(AbpLocalizationModule))]
public class AbpMessageServiceDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpMessageServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                   .Add<MessageServiceResource>("en")
                   .AddVirtualJson("/ZQH.Abp/MessageService/Localization/Resources");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(MessageServiceErrorCodes.Namespace, typeof(MessageServiceResource));
        });
    }
}
