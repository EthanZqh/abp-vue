

namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Models.PurchaseModels;


public record WebhookEvent1(string EventType, RunTaskWebhook1 Payload, DateTimeOffset Timestamp);
