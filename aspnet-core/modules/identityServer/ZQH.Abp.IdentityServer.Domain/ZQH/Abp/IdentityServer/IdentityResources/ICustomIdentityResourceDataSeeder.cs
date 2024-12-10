using System.Threading.Tasks;

namespace ZQH.Abp.IdentityServer.IdentityResources;

public interface ICustomIdentityResourceDataSeeder
{
    Task CreateCustomResourcesAsync();
}
