using Microsoft.Extensions.Logging;
using Volo.Abp.Data;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EntityFrameworkCore.Migrations;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace ZQH.MicroService.Onboarding.EntityFrameworkCore;
public class OnboardingDbMigrationEventHandler : EfCoreDatabaseMigrationEventHandlerBase<OnboardingMigrationsDbContext>
{
    public OnboardingDbMigrationEventHandler(
        ICurrentTenant currentTenant,
        IUnitOfWorkManager unitOfWorkManager,
        ITenantStore tenantStore,
        IAbpDistributedLock abpDistributedLock,
        IDistributedEventBus distributedEventBus,
        ILoggerFactory loggerFactory) 
        : base(
            ConnectionStringNameAttribute.GetConnStringName<OnboardingMigrationsDbContext>(), 
            currentTenant, unitOfWorkManager, tenantStore, abpDistributedLock, distributedEventBus, loggerFactory)
    {
    }
}
