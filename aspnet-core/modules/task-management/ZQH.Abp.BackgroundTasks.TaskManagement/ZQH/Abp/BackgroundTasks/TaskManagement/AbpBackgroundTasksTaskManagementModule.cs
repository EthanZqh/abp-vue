using ZQH.Abp.TaskManagement.HttpApi.Client;
using Volo.Abp.Modularity;

namespace ZQH.Abp.BackgroundTasks.TaskManagement;

[DependsOn(typeof(AbpBackgroundTasksModule))]
[DependsOn(typeof(TaskManagementHttpApiClientModule))]
public class AbpBackgroundTasksTaskManagementModule : AbpModule
{

}
