﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;
using Volo.Abp.Data;
using ZQH.MicroService.Onboarding.EntityFrameworkCore;

namespace ZQH.MicroService.Onloading.DbMigrator;

public class OnloadingDbMigratorHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;

    public OnloadingDbMigratorHostedService(
        IHostApplicationLifetime hostApplicationLifetime, 
        IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory
            .CreateAsync<OnloadingManagementDbMigratorModule>(options =>
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

