using Microsoft.EntityFrameworkCore;
using ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Entities;

namespace ZQH.MicroService.WorkflowsManagement.ElsaHttpApi.Host.Data;

public class OnboardingDbContext(DbContextOptions<OnboardingDbContext> options) : DbContext(options)
{
    public DbSet<OnboardingTask> Tasks { get; set; } = default!;
    public DbSet<PurchaseTask> PurchaseTaskTasks { get; set; } = default!;
}
