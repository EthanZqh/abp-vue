using ZQH.Abp.SettingManagement;
using ZQH.Abp.Tencent.QQ;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace ZQH.Abp.Tencent.SettingManagement;

[DependsOn(
    typeof(AbpTencentCloudModule),
    typeof(AbpTencentQQModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AbpTencentCloudSettingManagementModule : AbpModule
{

}