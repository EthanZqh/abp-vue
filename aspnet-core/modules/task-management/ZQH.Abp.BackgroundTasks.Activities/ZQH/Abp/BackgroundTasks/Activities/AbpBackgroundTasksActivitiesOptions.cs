using Volo.Abp.Collections;

namespace ZQH.Abp.BackgroundTasks.Activities;

public class AbpBackgroundTasksActivitiesOptions
{
    public ITypeList<IJobActionDefinitionProvider> DefinitionProviders { get; }

    public AbpBackgroundTasksActivitiesOptions()
    {
        DefinitionProviders = new TypeList<IJobActionDefinitionProvider>();
    }
}
