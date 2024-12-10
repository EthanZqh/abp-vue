//using ZQH.Abp.Saas.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagement.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace ZQH.Microservices.Product.EntityFrameworkCore;
public class ProductMigrationsDbContext : AbpDbContext<ProductMigrationsDbContext>
{
    public ProductMigrationsDbContext(DbContextOptions<ProductMigrationsDbContext> options)
      : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.ConfigureIdentity();
        //modelBuilder.ConfigureSaas();
        modelBuilder.ConfigureProductManagement();
       
      
    
    }

}
