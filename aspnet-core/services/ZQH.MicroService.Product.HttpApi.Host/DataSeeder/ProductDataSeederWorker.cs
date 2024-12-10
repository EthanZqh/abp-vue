using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace ZQH.MicroService.Product.HttpApi.Host.DataSeeder;

public class ProductDataSeederWorker : BackgroundService
{
    protected IDataSeeder DataSeeder { get; }

    public ProductDataSeederWorker(IDataSeeder dataSeeder)
    {
        DataSeeder = dataSeeder;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DataSeeder.SeedAsync();
    }
}
