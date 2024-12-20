using ZQH.Abp.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.Abp.Identity.EntityFrameworkCore.Employees;
[ConnectionStringName("AbpIdentity")]
public interface IEmployeeDbContext : IEfCoreDbContext
{
    DbSet<Employee> Employees { get; }
}
