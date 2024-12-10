using JetBrains.Annotations;
using ZQH.Abp.BackgroundTasks.Activities;
using ZQH.Abp.BackgroundTasks.Localization;
using ZQH.Abp.Notifications;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TextTemplating;

namespace ZQH.Abp.BackgroundTasks.Notifications;

public class JobExecutedSuccessedNotificationProvider : NotificationJobExecutedProvider
{
    public const string Name = "JobExecutedSuccessedNofiter";

    public JobExecutedSuccessedNotificationProvider(
        ICurrentTenant currentTenant, 
        INotificationSender notificationSender, 
        ITemplateRenderer templateRenderer, 
        IStringLocalizer<BackgroundTasksResource> stringLocalizer) 
        : base(currentTenant, notificationSender, templateRenderer, stringLocalizer)
    {
    }

    public async override Task NotifySuccessAsync([NotNull] JobActionExecuteContext context)
    {
        var title = StringLocalizer["JobExecutedSucceeded"].Value;

        await SendNofiterAsync(context, title, NotificationSeverity.Success);
    }
}
