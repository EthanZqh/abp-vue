using System.Collections.Generic;

namespace ZQH.Abp.Cli.ServiceProxying.TypeScript;

public class TypeScriptServiceProxyOptions
{
    public IDictionary<string, IHttpApiScriptGenerator> ScriptGenerators { get; }
    public TypeScriptServiceProxyOptions()
    {
        ScriptGenerators = new Dictionary<string, IHttpApiScriptGenerator>();
    }
}
