namespace ZQH.Abp.Notifications;
public interface INotificationDataSerializer
{
    NotificationData Serialize(NotificationData source);
}
