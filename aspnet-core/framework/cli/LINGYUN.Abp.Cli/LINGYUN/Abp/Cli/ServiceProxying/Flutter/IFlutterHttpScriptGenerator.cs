using Volo.Abp.Http.Modeling;

namespace ZQH.Abp.Cli.ServiceProxying.Flutter;
public interface IFlutterHttpScriptGenerator
{
    string CreateScript(
        ApplicationApiDescriptionModel appModel,
        ModuleApiDescriptionModel apiModel,
        ControllerApiDescriptionModel actionModel);
}
