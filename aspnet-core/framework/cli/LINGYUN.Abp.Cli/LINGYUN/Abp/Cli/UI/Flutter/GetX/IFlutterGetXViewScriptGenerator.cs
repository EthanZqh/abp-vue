using System.Threading.Tasks;
using Volo.Abp.Http.Modeling;

namespace ZQH.Abp.Cli.UI.Flutter.GetX;
public interface IFlutterGetXViewScriptGenerator
{
    Task<string> CreateView(
        GenerateViewArgs args,
        ApplicationApiDescriptionModel appModel,
        ControllerApiDescriptionModel controllerModel);
}
