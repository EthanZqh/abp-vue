using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZQH.Microservices.Product.EntityFrameworkCore;
public class ProductMigrationsDbContextFactory : IDesignTimeDbContextFactory<ProductMigrationsDbContext>
{
    public ProductMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString("Default");

        var builder = new DbContextOptionsBuilder<ProductMigrationsDbContext>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new ProductMigrationsDbContext(builder!.Options);


        //var configuration = BuildConfiguration();

        //var builder = new DbContextOptionsBuilder<ProductMigrationsDbContext>()
        //    .UseSqlServer(configuration.GetConnectionString("ProductManagement"));

        //return new ProductMigrationsDbContext(builder.Options);
    }


    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ZQH.Microservices.Product.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
