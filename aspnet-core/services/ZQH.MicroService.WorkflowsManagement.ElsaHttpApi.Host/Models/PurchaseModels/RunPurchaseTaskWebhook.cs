

namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Models.PurchaseModels;

public record RunTaskWebhook1(string WorkflowInstanceId, string TaskId, string TaskName, TaskPayload1 TaskPayload);