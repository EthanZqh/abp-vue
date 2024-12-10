using ZQH.MicroService.AuthServer.DataSeeder;
using Microsoft.Extensions.DependencyInjection;

namespace ZQH.MicroService.AuthServer;

public partial class AuthServerModule
{
    private static void ConfigureSeedWorker(IServiceCollection services, bool isDevelopment = false)
    {
        if (isDevelopment)
        {
            services.AddHostedService<AuthServerDataSeederWorker>();
        }
    }
}
