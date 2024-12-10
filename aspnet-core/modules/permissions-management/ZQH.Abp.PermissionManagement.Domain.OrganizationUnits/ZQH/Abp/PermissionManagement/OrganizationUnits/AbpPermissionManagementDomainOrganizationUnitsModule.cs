﻿using ZQH.Abp.Authorization.OrganizationUnits;
using ZQH.Abp.Authorization.Permissions;
using ZQH.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace ZQH.Abp.PermissionManagement.OrganizationUnits;

[DependsOn(
    typeof(AbpIdentityDomainModule),
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpAuthorizationOrganizationUnitsModule)
    )]
public class AbpPermissionManagementDomainOrganizationUnitsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<PermissionManagementOptions>(options =>
        {
            options.ManagementProviders.Add<OrganizationUnitPermissionManagementProvider>();

            options.ProviderPolicies[OrganizationUnitPermissionValueProvider.ProviderName] = "AbpIdentity.OrganizationUnits.ManagePermissions";
        });
    }
}
