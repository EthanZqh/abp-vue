﻿using ZQH.Abp.IM.Messages;
using ZQH.Abp.MessageService.Chat;
using System;

namespace ZQH.Abp.MessageService.Groups;

public class GroupMessage : Message
{
    /// <summary>
    /// 群组标识
    /// </summary>
    public virtual long GroupId { get; protected set; }

    protected GroupMessage() { }
    public GroupMessage(
        long id,
        Guid sendUserId,
        string sendUserName,
        long groupId,
        string content,
        MessageType type = MessageType.Text,
        MessageSourceType source = MessageSourceType.User,
        Guid? tenantId = null)
        : base(id, sendUserId, sendUserName, content, type, source, tenantId)
    {
        GroupId = groupId;
    }
}
