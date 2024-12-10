using Volo.Abp.Data;

namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host.ElsaHttpApi.Host.DataSeeder;

public class OnboardingDataSeederWorker : BackgroundService
{
    protected IDataSeeder DataSeeder { get; }

    public OnboardingDataSeederWorker(IDataSeeder dataSeeder)
    {
        DataSeeder = dataSeeder;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DataSeeder.SeedAsync();
    }
}