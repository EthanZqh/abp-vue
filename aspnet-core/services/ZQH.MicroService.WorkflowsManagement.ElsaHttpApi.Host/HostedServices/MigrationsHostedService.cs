
using Microsoft.EntityFrameworkCore;
using ZQH.Abp.Onboarding.EntityFrameworkCore;

namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.HostedServices;

public class MigrationsHostedService(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<OnboardingDbContext>>();
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        await dbContext.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}