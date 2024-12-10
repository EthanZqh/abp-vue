using System.Threading.Tasks;

namespace ZQH.Abp.EventBus.CAP;

public interface IFailedThresholdCallbackNotifier
{
    Task NotifyAsync(AbpCAPExecutionFailedException exception);
}
