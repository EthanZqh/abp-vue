using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.MicroService.ElsaServer.EntityFrameworkCore;
[ConnectionStringName("LocalizationManagementDbMigrator")]
public class ElsaServerMigrationsDbContext : AbpDbContext<ElsaServerMigrationsDbContext>
{
    public ElsaServerMigrationsDbContext(DbContextOptions<ElsaServerMigrationsDbContext> options)
     : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ConfigureOnboarding();
        modelBuilder.c
    }

}
