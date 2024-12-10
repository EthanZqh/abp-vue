using ZQH.MicroService.RealtimeMessage.DataSeeder;
using Microsoft.Extensions.DependencyInjection;

namespace ZQH.MicroService.RealtimeMessage;

public partial class RealtimeMessageHttpApiHostModule
{
    private static void ConfigureSeedWorker(IServiceCollection services, bool isDevelopment = false)
    {
        if (isDevelopment)
        {
            services.AddHostedService<RealtimeMessageDataSeederWorker>();
        }
    }
}
