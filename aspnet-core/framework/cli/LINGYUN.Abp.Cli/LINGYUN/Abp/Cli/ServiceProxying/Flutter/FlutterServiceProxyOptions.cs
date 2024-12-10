using System.Collections.Generic;

namespace ZQH.Abp.Cli.ServiceProxying.Flutter;
public class FlutterServiceProxyOptions
{
    public IDictionary<string, IFlutterHttpScriptGenerator> ScriptGenerators { get; }
    public FlutterServiceProxyOptions()
    {
        ScriptGenerators = new Dictionary<string, IFlutterHttpScriptGenerator>();
    }
}
