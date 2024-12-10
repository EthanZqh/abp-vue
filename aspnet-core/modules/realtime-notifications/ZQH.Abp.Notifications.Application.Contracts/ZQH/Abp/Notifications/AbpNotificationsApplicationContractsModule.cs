﻿using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Notifications;

[DependsOn(
    typeof(AbpNotificationsDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationAbstractionsModule))]
public class AbpNotificationsApplicationContractsModule : AbpModule
{

}
