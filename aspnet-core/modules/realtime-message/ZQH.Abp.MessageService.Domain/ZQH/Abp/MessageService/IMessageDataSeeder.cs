using System;
using System.Threading.Tasks;

namespace ZQH.Abp.MessageService;

public interface IMessageDataSeeder
{
    Task SeedAsync(Guid? tenantId = null);
}
