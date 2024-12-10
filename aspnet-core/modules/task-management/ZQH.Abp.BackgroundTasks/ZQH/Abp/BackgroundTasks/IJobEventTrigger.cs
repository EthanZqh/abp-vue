using System.Threading.Tasks;

namespace ZQH.Abp.BackgroundTasks;

public interface IJobEventTrigger
{
    Task OnJobBeforeExecuted(JobEventContext context);

    Task OnJobAfterExecuted(JobEventContext context);
}
