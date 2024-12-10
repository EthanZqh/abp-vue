﻿using ZQH.Abp.WeChat.Common.Messages;
using Volo.Abp.EventBus;

namespace ZQH.Abp.WeChat.Work.Common.Messages.Models;
/// <summary>
/// 长期未使用应用临时停用事件
/// </summary>
[EventName("close_inactive_agent")]
public class CloseInActiveAgentEvent : WeChatWorkEventMessage
{
    public override WeChatMessageEto ToEto()
    {
        return new WeChatWorkEventMessageEto<CloseInActiveAgentEvent>(this);
    }
}
