﻿using System.Threading.Tasks;

namespace ZQH.Abp.WeChat.Common.Messages.Handlers;
public interface IMessageHandler
{
    Task HandleEventAsync<TMessage>(TMessage data) where TMessage : WeChatEventMessage;

    Task HandleMessageAsync<TMessage>(TMessage data) where TMessage : WeChatGeneralMessage;
}
