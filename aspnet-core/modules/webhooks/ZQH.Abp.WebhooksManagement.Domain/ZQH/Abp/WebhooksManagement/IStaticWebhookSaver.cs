using System.Threading.Tasks;

namespace ZQH.Abp.WebhooksManagement;

public interface IStaticWebhookSaver
{
    Task SaveAsync();
}
