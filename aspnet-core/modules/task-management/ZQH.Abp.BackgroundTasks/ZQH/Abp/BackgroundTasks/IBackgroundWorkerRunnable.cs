using System.Threading;
using Volo.Abp.BackgroundWorkers;

namespace ZQH.Abp.BackgroundTasks;

public interface IBackgroundWorkerRunnable : IJobRunnable
{
#nullable enable
    JobInfo? BuildWorker(IBackgroundWorker worker);
#nullable disable
}
