using System.Threading.Tasks;

namespace ZQH.Abp.Notifications;
public interface IStaticNotificationSaver
{
    Task SaveAsync();
}
