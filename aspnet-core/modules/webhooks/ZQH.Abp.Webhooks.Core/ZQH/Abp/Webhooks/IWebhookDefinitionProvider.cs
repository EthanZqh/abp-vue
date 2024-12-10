namespace ZQH.Abp.Webhooks;

public interface IWebhookDefinitionProvider
{
    void Define(IWebhookDefinitionContext context);
}
