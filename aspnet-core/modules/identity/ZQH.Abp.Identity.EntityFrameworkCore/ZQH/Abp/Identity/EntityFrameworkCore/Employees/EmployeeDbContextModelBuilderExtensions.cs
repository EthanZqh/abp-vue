using ZQH.Abp.Employees;
using ZQH.Abp.Identity.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ZQH.Abp.Identity.EntityFrameworkCore.Employees;
public static class EmployeeDbContextModelBuilderExtensions
{
    public static void ConfigureEmployee(
   this ModelBuilder builder,
   Action<CusEmployeesModelBuilderConfigurationOptions> optionsAction = null)
    {
        Check.NotNull(builder, nameof(builder));

        var options = new CusEmployeesModelBuilderConfigurationOptions(
            CusEmployeesDbProperties.DefaultTablePrefix,
            CusEmployeesDbProperties.DefaultSchema
        );

        optionsAction?.Invoke(options);

        builder.Entity<Employee>(b =>
        {
            b.ToTable(options.TablePrefix + "Employees", options.Schema);
            b.ConfigureByConvention();

            b.Property(p => p.EmployeeName)
                .HasMaxLength(EmployeeConsts.MaxNameLength)
                .HasColumnName(nameof(Employee.EmployeeName))
                .IsRequired();
            b.Property(p => p.Sex)
                .HasMaxLength(EmployeeConsts.MaxSexLength)
                .HasColumnName(nameof(Employee.Sex));
            b.Property(p => p.Birthday)
                .HasMaxLength(EmployeeConsts.MaxBirthdayLength)
                .HasColumnName(nameof(Employee.Birthday));
            b.Property(p => p.AvatarUrl)
                .HasMaxLength(EmployeeConsts.MaxAvatarUrlLength)
                .HasColumnName(nameof(Employee.AvatarUrl));
            b.Property(p => p.Address)
                .HasMaxLength(EmployeeConsts.MaxAddressLength)
                .HasColumnName(nameof(Employee.Address));
            b.Property(p => p.Nation)
                .HasMaxLength(EmployeeConsts.MaxNationLength)
                .HasColumnName(nameof(Employee.Nation));
            b.Property(p => p.NativePlace)
                .HasMaxLength(EmployeeConsts.MaxNativePlaceLength)
                .HasColumnName(nameof(Employee.NativePlace));
            b.Property(p => p.PhoneNumber)
                .HasMaxLength(EmployeeConsts.MaxPhoneNumberLength)
                .HasColumnName(nameof(Employee.PhoneNumber));
            b.Property(p => p.Position)
                .HasMaxLength(EmployeeConsts.MaxPositionLength)
                .HasColumnName(nameof(Employee.Position));
            b.HasIndex(p => p.EmployeeName);
            b.ApplyObjectExtensionMappings();
        });

        builder.Entity<UserEmployee>(b =>
        {
            b.ToTable(options.TablePrefix + "UserEmployees", options.Schema);
            b.ConfigureByConvention();
            b.ApplyObjectExtensionMappings();
        });


    }
}
