﻿using ZQH.Abp.Authorization.OrganizationUnits;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;

namespace ZQH.Abp.Identity.OrganizaztionUnits;

[DependsOn(typeof(AbpIdentityDomainModule))]
[DependsOn(typeof(AbpAuthorizationOrganizationUnitsModule))]
public class AbpIdentityOrganizaztionUnitsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            options.DynamicClaims.Add(AbpOrganizationUnitClaimTypes.OrganizationUnit);
        });
    }
}
