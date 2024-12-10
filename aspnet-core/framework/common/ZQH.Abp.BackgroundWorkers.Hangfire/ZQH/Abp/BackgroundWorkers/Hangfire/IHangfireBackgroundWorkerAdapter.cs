using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers;

namespace ZQH.Abp.BackgroundWorkers.Hangfire;

public interface IHangfireBackgroundWorkerAdapter : IBackgroundWorker
{
    Task ExecuteAsync(CancellationToken cancellationToken = default);
}
