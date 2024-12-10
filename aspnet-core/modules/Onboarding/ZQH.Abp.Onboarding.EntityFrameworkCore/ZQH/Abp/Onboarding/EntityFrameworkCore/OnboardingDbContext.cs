using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using ZQH.Abp.Onboarding.Entities;
using ZQH.Platform.EntityFrameworkCore;

namespace ZQH.Abp.Onboarding.EntityFrameworkCore;
[ConnectionStringName("OnboardingManagement")]
public class OnboardingDbContext : AbpDbContext<OnboardingDbContext>, IOnboardingDbContext
{
    public OnboardingDbContext(DbContextOptions<OnboardingDbContext> options)
    : base(options)
    {
    }
    //public DbSet<OnboardingTask> Tasks => throw new NotImplementedException();
    public DbSet<OnboardingTask> Tasks { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
 

        base.OnModelCreating(builder);

        builder.ConfigureOnboarding();
    }
}
