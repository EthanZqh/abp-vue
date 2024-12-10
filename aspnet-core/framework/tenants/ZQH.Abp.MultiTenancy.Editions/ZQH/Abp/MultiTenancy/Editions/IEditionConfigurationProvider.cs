using System;
using System.Threading.Tasks;

namespace ZQH.Abp.MultiTenancy.Editions;

public interface IEditionConfigurationProvider
{
    Task<EditionConfiguration> GetAsync(Guid? tenantId = null);
}
