namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Models;

public record WebhookEvent(string EventType, RunTaskWebhook Payload, DateTimeOffset Timestamp);