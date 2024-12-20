using ZQH.Abp.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace ZQH.Abp.Identity.EntityFrameworkCore.Employees;
//[ReplaceDbContext(typeof(IIdentityDbContext))]
[ConnectionStringName("AbpIdentity")] 
public class EmployeeDbContext : AbpDbContext<EmployeeDbContext>, IEmployeeDbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<UserEmployee> UserEmployees { get; set; }


    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
    : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureEmployee();
        
    }
}
