using ZQH.Abp.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZQH.Abp.Identity.EntityFrameworkCore.Employees;
public static class EmployeeEfCoreQueryableExtensions
{
    public static IQueryable<Employee> IncludeDetails(this IQueryable<Employee> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            .Include(x => x.EmployeeName);
    }
}
