

namespace ZQH.Abp.Onboarding.Models.PurchaseModels;


public record WebhookEvent1(string EventType, RunTaskWebhook1 Payload, DateTimeOffset Timestamp);
