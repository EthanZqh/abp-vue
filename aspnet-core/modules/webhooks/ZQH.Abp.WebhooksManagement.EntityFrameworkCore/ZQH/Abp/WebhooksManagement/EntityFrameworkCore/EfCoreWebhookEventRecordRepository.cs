﻿using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.Abp.WebhooksManagement.EntityFrameworkCore;

public class EfCoreWebhookEventRecordRepository : 
    EfCoreRepository<IWebhooksManagementDbContext, WebhookEventRecord, Guid>, 
    IWebhookEventRecordRepository
{
    public EfCoreWebhookEventRecordRepository(IDbContextProvider<IWebhooksManagementDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }
}
