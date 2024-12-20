using JetBrains.Annotations;
using ZQH.Abp.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ZQH.Abp.Identity.EntityFrameworkCore.Employees;
public class CusEmployeesModelBuilderConfigurationOptions: AbpModelBuilderConfigurationOptions
{
    public CusEmployeesModelBuilderConfigurationOptions(
        [NotNull] string tablePrefix = CusEmployeesDbProperties.DefaultTablePrefix,
        [CanBeNull] string schema = CusEmployeesDbProperties.DefaultSchema
        ) :base( tablePrefix, schema )
    { }   
}
