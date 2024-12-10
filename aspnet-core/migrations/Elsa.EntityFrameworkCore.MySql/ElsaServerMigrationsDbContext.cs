using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Elsa.EntityFrameworkCore.MySql;
public class ElsaServerMigrationsDbContext : AbpDbContext<ElsaServerMigrationsDbContext>
{
    public ElsaServerMigrationsDbContext(DbContextOptions<ElsaServerMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyEntityConfigurations();
    }
}
