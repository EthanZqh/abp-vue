using System.Threading.Tasks;

namespace ZQH.Abp.Saas.Editions;

public interface IEditionDataSeeder
{
    Task SeedDefaultEditionsAsync();
}
