using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using ZQH.Microservices.Product.EntityFrameworkCore;

namespace ZQH.Microservices.Product.DbMigrator;
internal class ProductServerDbMigratorHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;
    public ProductServerDbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory
           .CreateAsync<ProductServerDbMigratorModule>(options =>
           {
               options.Services.ReplaceConfiguration(_configuration);
               options.UseAutofac();
               options.Services.AddLogging(c => c.AddSerilog());
               options.AddDataMigrationEnvironment();
           });
        await application.InitializeAsync();

        await application
            .ServiceProvider
            .GetRequiredService<ProductServerDbMigrationService>()
            .MigrateAsync();

        await application.ShutdownAsync();

        _hostApplicationLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
