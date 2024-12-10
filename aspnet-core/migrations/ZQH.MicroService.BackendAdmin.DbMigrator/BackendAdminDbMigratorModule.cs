using ZQH.Abp.Auditing;
using ZQH.Abp.CachingManagement;
using ZQH.Abp.Identity;
using ZQH.Abp.IdentityServer;
using ZQH.Abp.LocalizationManagement;
using ZQH.Abp.MessageService;
using ZQH.Abp.Notifications;
using ZQH.Abp.OpenIddict;
using ZQH.Abp.OssManagement;
using ZQH.Abp.SettingManagement;
using ZQH.Abp.TaskManagement;
using ZQH.Abp.TextTemplating;
using ZQH.Abp.WebhooksManagement;
using ZQH.Platform;
using ZQH.MicroService.BackendAdmin.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace ZQH.MicroService.BackendAdmin.DbMigrator;

[DependsOn(
    typeof(BackendAdminMigrationsEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpLocalizationManagementApplicationContractsModule),
    typeof(AbpCachingManagementApplicationContractsModule),
    typeof(AbpAuditingApplicationContractsModule),
    typeof(AbpTextTemplatingApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpIdentityServerApplicationContractsModule),
    typeof(AbpOpenIddictApplicationContractsModule),
    typeof(PlatformApplicationContractModule),
    typeof(AbpOssManagementApplicationContractsModule),
    typeof(AbpNotificationsApplicationContractsModule),
    typeof(AbpMessageServiceApplicationContractsModule),
    typeof(TaskManagementApplicationContractsModule),
    typeof(WebhooksManagementApplicationContractsModule),
    typeof(AbpAutofacModule)
    )]
public partial class BackendAdminDbMigratorModule : AbpModule
{
}
