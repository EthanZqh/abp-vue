using JetBrains.Annotations;

namespace ZQH.Abp.BackgroundTasks.Activities;

public class JobActionExecuteContext
{
    public JobAction Action { get; }
    public JobEventContext Event { get; }
    public JobActionExecuteContext(
        [NotNull] JobAction action,
        [NotNull] JobEventContext @event)
    {
        Action = action;
        Event = @event;
    }
}
