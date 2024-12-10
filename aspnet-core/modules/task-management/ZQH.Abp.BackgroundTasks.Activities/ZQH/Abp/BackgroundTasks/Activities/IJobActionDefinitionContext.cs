using System.Collections.Generic;

namespace ZQH.Abp.BackgroundTasks.Activities;

public interface IJobActionDefinitionContext
{
    JobActionDefinition GetOrNull(string name);

    IReadOnlyList<JobActionDefinition> GetAll();

    void Add(params JobActionDefinition[] definitions);
}
