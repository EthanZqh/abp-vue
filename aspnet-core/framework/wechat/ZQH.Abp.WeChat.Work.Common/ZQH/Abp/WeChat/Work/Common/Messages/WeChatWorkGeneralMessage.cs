﻿using ZQH.Abp.WeChat.Common.Messages;
using System.Xml.Serialization;

namespace ZQH.Abp.WeChat.Work.Common.Messages;
/// <summary>
/// 企业微信普通消息
/// </summary>
public abstract class WeChatWorkGeneralMessage : WeChatGeneralMessage
{
    /// <summary>
    /// 企业应用的id，整型。可在应用的设置页面查看
    /// </summary>
    [XmlElement("AgentID")]
    public int AgentId { get; set; }
}
