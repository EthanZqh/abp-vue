using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ZQH.Abp.DataProtectionManagement.EntityFrameworkCore;

public interface IAbpDataProtectionManagementDbContext : IEfCoreDbContext
{
    DbSet<EntityTypeInfo> EntityTypeInfos { get; set; }
}
