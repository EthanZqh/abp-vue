using ZQH.MicroService.PlatformManagement.DataSeeder;
using Microsoft.Extensions.DependencyInjection;

namespace ZQH.MicroService.PlatformManagement;

public partial class PlatformManagementHttpApiHostModule
{
    private static void ConfigureSeedWorker(IServiceCollection services, bool isDevelopment = false)
    {
        if (isDevelopment)
        {
            services.AddHostedService<PlatformManagementDataSeederWorker>();
        }
    }
}
