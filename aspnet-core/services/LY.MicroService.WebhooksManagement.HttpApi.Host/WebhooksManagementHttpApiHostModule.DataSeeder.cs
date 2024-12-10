using Microsoft.Extensions.DependencyInjection;
using ZQH.MicroService.WebhooksManagement.DataSeeder;

namespace ZQH.MicroService.WebhooksManagement;

public partial class WebhooksManagementHttpApiHostModule
{
    private static void ConfigureSeedWorker(IServiceCollection services, bool isDevelopment = false)
    {
        if (isDevelopment)
        {
            services.AddHostedService<WebhooksManagementDataSeederWorker>();
        }
    }
}
