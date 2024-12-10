using System.Collections.Generic;

namespace ZQH.Abp.Notifications;

public interface INotificationPublishProviderManager
{
    List<INotificationPublishProvider> Providers { get; }
}
