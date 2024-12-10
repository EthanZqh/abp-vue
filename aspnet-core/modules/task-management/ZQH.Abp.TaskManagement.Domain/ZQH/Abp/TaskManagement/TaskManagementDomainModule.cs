using ZQH.Abp.BackgroundTasks;
using ZQH.Abp.BackgroundTasks.Activities;
using ZQH.Abp.BackgroundTasks.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace ZQH.Abp.TaskManagement;

[DependsOn(typeof(TaskManagementDomainSharedModule))]
[DependsOn(typeof(AbpAutoMapperModule))]
[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(AbpBackgroundTasksModule))]
[DependsOn(typeof(AbpBackgroundTasksEventBusModule))]
[DependsOn(typeof(AbpBackgroundTasksActivitiesModule))]
public class TaskManagementDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<TaskManagementDomainModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<TaskManagementDomainMapperProfile>(validate: true);
        });

        Configure<AbpDistributedEntityEventOptions>(options =>
        {
            options.EtoMappings.Add<BackgroundJobInfo, BackgroundJobEto>(typeof(TaskManagementDomainModule));

            options.AutoEventSelectors.Add<BackgroundJobInfo>();
        });

    }
}