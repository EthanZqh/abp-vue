using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using ZQH.Abp.Onboarding;
using ZQH.Abp.Onboarding.Entities;

namespace ZQH.Abp.Onboarding.EntityFrameworkCore;
//[ConnectionStringName(AbpOnboardingDbProperties.ConnectionStringName)]
[ConnectionStringName("OnboardingManagement")]
public interface IOnboardingDbContext : IEfCoreDbContext
{
    DbSet<OnboardingTask> Tasks { get; }
    //DbSet<Tenant> Tenants { get; }
    //DbSet<TenantConnectionString> TenantConnectionStrings { get; }

}
