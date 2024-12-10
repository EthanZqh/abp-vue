using JetBrains.Annotations;
using ZQH.Abp.Webhooks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZQH.Abp.WebhooksManagement;

public interface IWebhookDefinitionSerializer
{
    Task<(WebhookGroupDefinitionRecord[], WebhookDefinitionRecord[])>
        SerializeAsync(IEnumerable<WebhookGroupDefinition> WebhookGroups);

    Task<WebhookGroupDefinitionRecord> SerializeAsync(
        WebhookGroupDefinition WebhookGroup);

    Task<WebhookDefinitionRecord> SerializeAsync(
        WebhookDefinition Webhook,
        [CanBeNull] WebhookGroupDefinition WebhookGroup);
}