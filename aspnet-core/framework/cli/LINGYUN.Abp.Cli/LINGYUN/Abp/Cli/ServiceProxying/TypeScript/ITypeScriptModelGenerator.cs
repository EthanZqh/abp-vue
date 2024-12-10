using Volo.Abp.Http.Modeling;

namespace ZQH.Abp.Cli.ServiceProxying.TypeScript;

public interface ITypeScriptModelGenerator
{
    string CreateScript(
        ApplicationApiDescriptionModel appModel,
        ControllerApiDescriptionModel actionModel);
}
