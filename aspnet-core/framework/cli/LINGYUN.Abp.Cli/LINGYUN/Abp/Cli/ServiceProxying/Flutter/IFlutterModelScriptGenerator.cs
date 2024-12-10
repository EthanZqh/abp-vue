using Volo.Abp.Http.Modeling;

namespace ZQH.Abp.Cli.ServiceProxying.Flutter;

public interface IFlutterModelScriptGenerator
{
    string CreateScript(
        ApplicationApiDescriptionModel appModel,
        ControllerApiDescriptionModel actionModel);
}
