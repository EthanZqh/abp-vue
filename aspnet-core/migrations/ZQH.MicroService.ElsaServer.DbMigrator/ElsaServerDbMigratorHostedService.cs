using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ZQH.MicroService.ElsaServer.DbMigrator;
public class ElsaServerDbMigratorHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;

    public ElsaServerDbMigratorHostedService(
        IHostApplicationLifetime hostApplicationLifetime,
        IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory
    .CreateAsync<ElsaServerManagementDbMigratorModule>(options =>
    {
        // 从环境变量取用户机密配置, 适用于容器测试
        options.Configuration.UserSecretsId = Environment.GetEnvironmentVariable("APPLICATION_USER_SECRETS_ID");
        // 如果容器没有指定用户机密, 从项目读取
        options.Configuration.UserSecretsAssembly = typeof(OnloadingDbMigratorHostedService).Assembly;
        options.Services.ReplaceConfiguration(_configuration);
        options.UseAutofac();
        options.Services.AddLogging(c => c.AddSerilog());
        options.AddDataMigrationEnvironment();
    });
        await application.InitializeAsync();

        await application
            .ServiceProvider
            .GetRequiredService<OnboardingDbMigrationService>()
            .CheckAndApplyDatabaseMigrationsAsync();

        await application.ShutdownAsync();

        _hostApplicationLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
