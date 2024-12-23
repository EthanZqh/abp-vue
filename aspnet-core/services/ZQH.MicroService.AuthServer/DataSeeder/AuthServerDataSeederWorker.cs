﻿using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace ZQH.MicroService.AuthServer.DataSeeder;

public class AuthServerDataSeederWorker : BackgroundService
{
    protected IDataSeeder DataSeeder { get; }

    public AuthServerDataSeederWorker(IDataSeeder dataSeeder)
    {
        DataSeeder = dataSeeder;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DataSeeder.SeedAsync();
    }
}
