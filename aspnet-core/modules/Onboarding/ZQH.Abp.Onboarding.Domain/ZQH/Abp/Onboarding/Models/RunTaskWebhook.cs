namespace ZQH.Abp.Onboarding.Models;

public record RunTaskWebhook(string WorkflowInstanceId, string TaskId, string TaskName, TaskPayload TaskPayload);