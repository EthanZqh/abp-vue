namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Models;

public record RunTaskWebhook(string WorkflowInstanceId, string TaskId, string TaskName, TaskPayload TaskPayload);