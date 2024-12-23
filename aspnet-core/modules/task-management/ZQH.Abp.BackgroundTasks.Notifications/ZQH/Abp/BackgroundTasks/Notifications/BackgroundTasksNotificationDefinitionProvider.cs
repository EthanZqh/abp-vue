﻿using ZQH.Abp.BackgroundTasks.Localization;
using ZQH.Abp.Notifications;
using Volo.Abp.Localization;

namespace ZQH.Abp.BackgroundTasks.Notifications;

public class BackgroundTasksNotificationDefinitionProvider : NotificationDefinitionProvider
{
    public override void Define(INotificationDefinitionContext context)
    {
        var backgroundTaskGroup = context.AddGroup(
                BackgroundTasksNotificationNames.GroupName,
                L("Notifications:BackgroundTasks"));

        backgroundTaskGroup.AddNotification(
            BackgroundTasksNotificationNames.JobExecuteSucceeded,
            L("Notifications:JobExecuteSucceeded"),
            L("Notifications:JobExecuteSucceededDesc"),
            notificationType: NotificationType.Application,
            lifetime: NotificationLifetime.Persistent,
            contentType: NotificationContentType.Markdown,
            allowSubscriptionToClients: true)
            .WithProviders(
                NotificationProviderNames.SignalR,
                NotificationProviderNames.Emailing);
        backgroundTaskGroup.AddNotification(
            BackgroundTasksNotificationNames.JobExecuteFailed,
            L("Notifications:JobExecuteFailed"),
            L("Notifications:JobExecuteFailedDesc"),
            notificationType: NotificationType.Application,
            lifetime: NotificationLifetime.Persistent,
            contentType: NotificationContentType.Markdown,
            allowSubscriptionToClients: true)
            .WithProviders(
                NotificationProviderNames.SignalR,
                NotificationProviderNames.Emailing);
        backgroundTaskGroup.AddNotification(
            BackgroundTasksNotificationNames.JobExecuteCompleted,
            L("Notifications:JobExecuteCompleted"),
            L("Notifications:JobExecuteCompletedDesc"),
            notificationType: NotificationType.Application,
            lifetime: NotificationLifetime.Persistent,
            contentType: NotificationContentType.Markdown,
            allowSubscriptionToClients: true)
            .WithProviders(
                NotificationProviderNames.SignalR,
                NotificationProviderNames.Emailing);
    }

    protected LocalizableString L(string name)
    {
        return LocalizableString.Create<BackgroundTasksResource>(name);
    }
}
