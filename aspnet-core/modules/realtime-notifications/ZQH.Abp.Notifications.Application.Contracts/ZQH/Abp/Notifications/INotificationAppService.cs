using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Notifications;

public interface INotificationAppService
{
    Task<ListResultDto<NotificationGroupDto>> GetAssignableNotifiersAsync();

    Task<ListResultDto<NotificationTemplateDto>> GetAssignableTemplatesAsync();

    Task SendAsync(NotificationSendDto input);

    Task SendAsync(NotificationTemplateSendDto input);
}
