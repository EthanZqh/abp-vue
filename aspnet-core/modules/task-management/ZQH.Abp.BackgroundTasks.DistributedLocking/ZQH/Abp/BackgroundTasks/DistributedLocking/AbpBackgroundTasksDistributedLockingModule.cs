﻿using Volo.Abp.DistributedLocking;
using Volo.Abp.Modularity;

namespace ZQH.Abp.BackgroundTasks.DistributedLocking;

[DependsOn(typeof(AbpBackgroundTasksModule))]
[DependsOn(typeof(AbpDistributedLockingAbstractionsModule))]
public class AbpBackgroundTasksDistributedLockingModule : AbpModule
{

}
