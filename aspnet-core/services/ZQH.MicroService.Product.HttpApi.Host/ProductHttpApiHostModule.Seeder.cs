using Microsoft.Extensions.DependencyInjection;
using ZQH.MicroService.Product.HttpApi.Host.DataSeeder;

namespace ZQH.MicroService.Product.HttpApi.Host;

public partial class ProductHttpApiHostModule
{
    private static void ConfigureSeedWorker(IServiceCollection services, bool isDevelopment = false)
    {
        if (isDevelopment)
        {
            services.AddHostedService<ProductDataSeederWorker>();
        }
    }

}
