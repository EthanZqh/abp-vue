using ZQH.Abp.WeChat.Work.Chat.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ZQH.Abp.WeChat.Work.Chat.Response;
public class WeChatWorkAppChatInfoResponse : WeChatWorkResponse
{
    /// <summary>
    /// 群聊信息
    /// </summary>
    [JsonProperty("chat_info")]
    [JsonPropertyName("chat_info")]
    public WeChatWorkAppChatInfo ChatInfo { get; set; }
}
