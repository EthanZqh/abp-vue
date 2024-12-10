﻿using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Features;
using Volo.Abp.Modularity;

namespace ZQH.Abp.WebhooksManagement;

[DependsOn(
    typeof(AbpFeaturesModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(WebhooksManagementDomainSharedModule))]
public class WebhooksManagementApplicationContractsModule : AbpModule
{
}
