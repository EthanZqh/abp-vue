namespace ZQH.Abp.Notifications;

public interface INotificationDefinitionProvider
{
    void Define(INotificationDefinitionContext context);
}
