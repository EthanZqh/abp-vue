using JetBrains.Annotations;
using System.Collections.Generic;

namespace ZQH.Abp.WeChat.Work;
public class WeChatWorkApplicationConfigurationDictionary : Dictionary<string, WeChatWorkApplicationConfiguration>
{
    [NotNull]
    public WeChatWorkApplicationConfiguration GetConfiguration(string agentId)
    {
        return this.GetOrDefault(agentId)
               ?? throw new AbpWeChatWorkException("WeChatWork:100404", $"WeChat Work application was not found configuration with agent '{agentId}' .")
                    .WithData("AgentId", agentId);
    }
}
