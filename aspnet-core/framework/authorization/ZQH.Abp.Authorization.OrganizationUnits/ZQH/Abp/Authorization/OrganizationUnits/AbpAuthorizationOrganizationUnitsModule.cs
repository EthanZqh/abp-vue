﻿using ZQH.Abp.Authorization.Permissions;
using Volo.Abp.Authorization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Authorization.OrganizationUnits;

[DependsOn(typeof(AbpAuthorizationModule))]
public class AbpAuthorizationOrganizationUnitsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpPermissionOptions>(options =>
        {
            options.ValueProviders.Add<OrganizationUnitPermissionValueProvider>();
        });
    }
}
