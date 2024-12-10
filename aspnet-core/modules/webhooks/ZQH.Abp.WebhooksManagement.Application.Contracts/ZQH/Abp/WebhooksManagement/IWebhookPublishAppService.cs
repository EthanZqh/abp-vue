using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.WebhooksManagement;

public interface IWebhookPublishAppService : IApplicationService
{
    Task PublishAsync(WebhookPublishInput input);
}
