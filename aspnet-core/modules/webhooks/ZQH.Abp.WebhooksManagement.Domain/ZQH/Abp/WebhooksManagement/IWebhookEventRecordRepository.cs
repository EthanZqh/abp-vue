using System;
using Volo.Abp.Domain.Repositories;

namespace ZQH.Abp.WebhooksManagement;

public interface IWebhookEventRecordRepository : IRepository<WebhookEventRecord, Guid>
{
}
