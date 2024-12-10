using ZQH.Abp.BackgroundTasks;

namespace ZQH.Abp.TaskManagement;

public class BackgroundJobActionGetDefinitionsInput
{
    public JobActionType? Type { get; set; }
}
