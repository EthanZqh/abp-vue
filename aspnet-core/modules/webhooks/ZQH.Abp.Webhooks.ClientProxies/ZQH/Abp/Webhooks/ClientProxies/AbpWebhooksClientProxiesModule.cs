using ZQH.Abp.WebhooksManagement;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Webhooks.ClientProxies;

[DependsOn(typeof(AbpWebhooksModule))]
[DependsOn(typeof(WebhooksManagementHttpApiClientModule))]
public class AbpWebHooksClientProxiesModule : AbpModule
{
}
