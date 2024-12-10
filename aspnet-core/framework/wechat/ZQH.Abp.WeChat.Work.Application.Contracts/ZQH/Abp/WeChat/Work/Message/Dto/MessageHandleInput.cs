using ZQH.Abp.WeChat.Work.Models;
using System;
using Volo.Abp.Auditing;

namespace ZQH.Abp.WeChat.Work.Message;

[Serializable]
public class MessageHandleInput : WeChatWorkMessage
{
    [DisableAuditing]
    public string Data { get; set; }
}
