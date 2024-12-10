using System.Threading.Tasks;

namespace ZQH.Abp.Cli.UI;
public interface IViewGenerator
{
    Task GenerateAsync(GenerateViewArgs args);
}
