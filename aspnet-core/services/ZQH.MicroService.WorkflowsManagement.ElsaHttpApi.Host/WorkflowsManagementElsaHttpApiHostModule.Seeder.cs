using ZQH.MicroService.Workflows.ElsaHttpApi.Host.ElsaHttpApi.Host.DataSeeder;

//namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host.ElsaHttpApi.Host;
namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host;
public partial class WorkflowsManagementElsaHttpApiHostModule
{
    private static void ConfigureSeedWorker(IServiceCollection services, bool isDevelopment = false)
    {
        if (isDevelopment)
        {
            services.AddHostedService<OnboardingDataSeederWorker>();
        }
    }
}
