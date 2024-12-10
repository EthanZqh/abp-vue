﻿using ZQH.Abp.WeChat.Official.Models;
using System;
using Volo.Abp.Auditing;

namespace ZQH.Abp.WeChat.Official.Message;

[Serializable]
public class MessageHandleInput : WeChatMessage
{
    [DisableAuditing]
    public string Data { get; set; }
}
