using Activities;
using Elsa.EntityFrameworkCore.Extensions;
using Elsa.EntityFrameworkCore.Modules.Management;
using Elsa.EntityFrameworkCore.Modules.Runtime;
using Elsa.Extensions;
using Serilog;
using Volo.Abp.IO;
using Volo.Abp.Modularity.PlugIns;
using Elsa.EntityFrameworkCore.MySqlVersion8;
namespace ZQH.MicroService.Workflows.ElsaServer;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        try
        {
            Console.Title = "WorkflowManagement.ElsaServer.Host";
            Log.Information("Starting WorkflowManagement.ElsaServer.Host.");

            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseStaticWebAssets();
            builder.Services.AddElsa(elsa =>
            {
                //elsa.UseEntityFrameworkPersistence(ef => ef.UseSqlServer(builder.Configuration.GetConnectionString("Default"), typeof(Program)));
                // Configure Management layer to use EF Core.
                elsa.UseWorkflowManagement(management => management.UseEntityFrameworkCore(ef => ef.UseMySql(builder.Configuration.GetConnectionString("Default"))));
                //elsa.UseWorkflowManagement(management => management.UseEntityFrameworkCore(ef => ef.UseSqlServer(builder.Configuration.GetConnectionString("Default"))));
                //elsa.UseWorkflowManagement(management => management.UseEntityFrameworkCore());

                // Configure Runtime layer to use EF Core.
                //elsa.UseWorkflowRuntime(runtime => runtime.UseEntityFrameworkCore());
                elsa.UseWorkflowRuntime(runtime => runtime.UseEntityFrameworkCore(ef => ef.UseMySql(builder.Configuration.GetConnectionString("Default"))));
                //elsa.UseWorkflowRuntime(runtime => runtime.UseEntityFrameworkCore(ef => ef.UseSqlServer(builder.Configuration.GetConnectionString("Default"))));
                // Default Identity features for authentication/authorization.
                elsa.UseIdentity(identity =>
                {
                    identity.TokenOptions = options => options.SigningKey = "00000000-0000-0000-0000-000000000000"; // This key needs to be at least 256 bits long.
                    identity.UseAdminUserProvider();
                });

                // Configure ASP.NET authentication/authorization.
                elsa.UseDefaultAuthentication(auth => auth.UseAdminApiKey());

                // Expose Elsa API endpoints.
                elsa.UseWorkflowsApi();

                // Setup a SignalR hub for real-time updates from the server.
                elsa.UseRealTimeWorkflows();

                // Enable C# workflow expressions
                elsa.UseCSharp();

                // Enable JavaScript workflow expressions
                elsa.UseJavaScript(options => options.AllowClrAccess = true);

                // Enable HTTP activities.
                elsa.UseHttp(http => http.ConfigureHttpOptions = options => builder.Configuration.GetSection("Http").Bind(options));

                // Use timer activities.
                elsa.UseScheduling();

                // Use email activities.
                elsa.UseEmail(email =>
                {
                    email.ConfigureOptions = options =>
                    {
                        //options.Host = "127.0.0.1";
                        //options.Port = 2525;
                        options.Host = "smtp.126.com";
                        options.Port = 25;
                        options.UserName = "zqh_2023vip@126.com";
                        options.Password = "TMQGWBQSHEJKZMWU";
                        options.RequireCredentials = true;

                    };
                });

                // Register custom activities from the application, if any.
                elsa.AddActivitiesFrom<Program>();

                // Register custom workflows from the application, if any.
                elsa.AddWorkflowsFrom<Program>();

                // Register custom webhook definitions from the application, if any.
                elsa.UseWebhooks(webhooks => webhooks.WebhookOptions = options => builder.Configuration.GetSection("Webhooks").Bind(options));
                elsa.UseLiquid();
                //elsa.AddWorkflow<WeatherForecastWorkflow1>();
                //注册活动


                elsa.AddActivity<Greeter>();
                elsa.AddActivity<CheckUserRole>();


                //elsa.UseSasTokens();

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
            await builder.AddApplicationAsync<WorkflowManagementHttpApiHostModule>(options =>
            {
                WorkflowManagementHttpApiHostModule.ApplicationName = Environment.GetEnvironmentVariable("APPLICATION_NAME")
                    ?? WorkflowManagementHttpApiHostModule.ApplicationName;
                options.ApplicationName = WorkflowManagementHttpApiHostModule.ApplicationName;
                // 从环境变量取用户机密配置, 适用于容器测试
                options.Configuration.UserSecretsId = Environment.GetEnvironmentVariable("APPLICATION_USER_SECRETS_ID");
                // 如果容器没有指定用户机密, 从项目读取
                options.Configuration.UserSecretsAssembly = typeof(WorkflowManagementHttpApiHostModule).Assembly;
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
            app.MapFallbackToPage("/_Host");
            app.MapControllers();
            app.MapRazorPages();
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
}
