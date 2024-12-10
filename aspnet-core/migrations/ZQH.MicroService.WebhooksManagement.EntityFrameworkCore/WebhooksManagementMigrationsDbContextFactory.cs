﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ZQH.MicroService.WebhooksManagement.EntityFrameworkCore;

public class WebhooksManagementMigrationsDbContextFactory : IDesignTimeDbContextFactory<WebhooksManagementMigrationsDbContext>
{
    public WebhooksManagementMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString("Default");

        var builder = new DbContextOptionsBuilder<WebhooksManagementMigrationsDbContext>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new WebhooksManagementMigrationsDbContext(builder!.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ZQH.MicroService.WebhooksManagement.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
