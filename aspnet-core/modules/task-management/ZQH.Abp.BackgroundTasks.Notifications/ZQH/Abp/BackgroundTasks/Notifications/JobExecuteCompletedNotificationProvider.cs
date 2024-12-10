using JetBrains.Annotations;
using ZQH.Abp.BackgroundTasks.Activities;
using ZQH.Abp.BackgroundTasks.Localization;
using ZQH.Abp.Notifications;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TextTemplating;

namespace ZQH.Abp.BackgroundTasks.Notifications;

public class JobExecuteCompletedNotificationProvider : NotificationJobExecutedProvider
{
    public const string Name = "JobExecutedCompletedNofiter";

    public JobExecuteCompletedNotificationProvider(
        ICurrentTenant currentTenant, 
        INotificationSender notificationSender, 
        ITemplateRenderer templateRenderer, 
        IStringLocalizer<BackgroundTasksResource> stringLocalizer) 
        : base(currentTenant, notificationSender, templateRenderer, stringLocalizer)
    {
    }

    public async override Task NotifyComplateAsync([NotNull] JobActionExecuteContext context)
    {
        var title = StringLocalizer["JobExecutedCompleted"].Value;

        await SendNofiterAsync(context, title, NotificationSeverity.Info);
    }
}
