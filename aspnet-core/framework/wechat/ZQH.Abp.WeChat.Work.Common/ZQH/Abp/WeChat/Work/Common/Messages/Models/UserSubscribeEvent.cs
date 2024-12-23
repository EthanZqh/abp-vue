﻿using ZQH.Abp.WeChat.Common.Messages;
using Volo.Abp.EventBus;

namespace ZQH.Abp.WeChat.Work.Common.Messages.Models;
/// <summary>
/// 用户关注事件
/// </summary>
[EventName("user_subscribe")]
public class UserSubscribeEvent : WeChatWorkEventMessage
{
    public override WeChatMessageEto ToEto()
    {
        return new WeChatWorkEventMessageEto<UserSubscribeEvent>(this);
    }
}
