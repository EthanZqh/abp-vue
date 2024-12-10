
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net.Http.Headers;
using Volo.Abp.IO;
using Volo.Abp.Modularity.PlugIns;
using ZQH.Abp.Onboarding.Services;
using ZQH.Abp.Onboarding.EntityFrameworkCore;
using ZQH.MicroService.Workflows.ElsaHttpApi.Host;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.HostedServices;

namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host.ElsaHttpApi.Host;
        
public class Program
{
    public async static Task<int> Main(string[] args)
    {
        try
        {
            Console.Title = "WorkflowsManagement.ElsaHttpApi.Host";
            Log.Information("Starting WorkflowsManagement.ElsaHttpApi.Host.");

            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            //builder.Services.AddDbContextFactory<OnboardingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            //builder.Services.AddHostedService<MigrationsHostedService>();

            // Configure Elsa API client.
            builder.Services.AddHttpClient<ElsaClient>(httpClient =>
            {
                var url = configuration["Elsa:ServerUrl"]!.TrimEnd('/') + '/';
                var apiKey = configuration["Elsa:ApiKey"]!;
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", apiKey);
            });
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .ConfigureAppConfiguration((context, config) =>
                {
                    var configuration = config.Build();
                    var agileConfigEnabled = configuration["AgileConfig:IsEnabled"];
                    if (agileConfigEnabled.IsNullOrEmpty() || bool.Parse(agileConfigEnabled))
                    {
                        config.AddAgileConfig(new AgileConfig.Client.ConfigClient(configuration));
                    }
                })
                .UseSerilog((context, provider, config) =>
                {
                    config.ReadFrom.Configuration(context.Configuration);
                });
            await builder.AddApplicationAsync<WorkflowsManagementElsaHttpApiHostModule>(options =>
            {
                WorkflowsManagementElsaHttpApiHostModule.ApplicationName = Environment.GetEnvironmentVariable("APPLICATION_NAME")
                    ?? WorkflowsManagementElsaHttpApiHostModule.ApplicationName;
                options.ApplicationName = WorkflowsManagementElsaHttpApiHostModule.ApplicationName;
                // 从环境变量取用户机密配置, 适用于容器测试
                options.Configuration.UserSecretsId = Environment.GetEnvironmentVariable("APPLICATION_USER_SECRETS_ID");
                // 如果容器没有指定用户机密, 从项目读取
                options.Configuration.UserSecretsAssembly = typeof(WorkflowsManagementElsaHttpApiHostModule).Assembly;
                // 搜索 Modules 目录下所有文件作为插件
                // 取消显示引用所有其他项目的模块，改为通过插件的形式引用
                var pluginFolder = Path.Combine(
                        Directory.GetCurrentDirectory(), "Modules");
                DirectoryHelper.CreateIfNotExists(pluginFolder);
                options.PlugInSources.AddFolder(
                    pluginFolder,
                    SearchOption.AllDirectories);
            });
            var app = builder.Build();
            await app.InitializeApplicationAsync();

            // Create a sample weather forecast API.


            //var summaries = new[]
            //{
            //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            //};

            //app.MapGet("/weatherforecast", () =>
            //{
            //    var forecast = Enumerable.Range(1, 5).Select(index =>
            //            new WeatherForecast
            //            (
            //                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //                Random.Shared.Next(-20, 55),
            //                summaries[Random.Shared.Next(summaries.Length)]
            //            ))
            //        .ToArray();
            //    return forecast;
            //});
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            Console.WriteLine("Host terminated unexpectedly!");
            Console.WriteLine(ex.ToString());
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }


    //record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    //{
    //    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    //}
}
