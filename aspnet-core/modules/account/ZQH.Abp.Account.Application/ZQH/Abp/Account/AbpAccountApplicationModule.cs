using ZQH.Abp.Account.Templates;
using ZQH.Abp.Identity;
using ZQH.Abp.WeChat.MiniProgram;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace ZQH.Abp.Account;

[DependsOn(
    typeof(Volo.Abp.Account.AbpAccountApplicationModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpAccountTemplatesModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpWeChatMiniProgramModule))]
public class AbpAccountApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpAccountApplicationModule>();
        });

        Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].Urls[AccountUrlNames.EmailConfirm] = "Account/EmailConfirm";
        });
    }
}
