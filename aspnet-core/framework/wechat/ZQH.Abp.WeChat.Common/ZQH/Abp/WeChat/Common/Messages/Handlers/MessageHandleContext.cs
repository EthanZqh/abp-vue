﻿using System;

namespace ZQH.Abp.WeChat.Common.Messages.Handlers;
public class MessageHandleContext<TMessage> where TMessage : WeChatMessage
{
    public TMessage Message { get; }
    public IServiceProvider ServiceProvider { get; }
    public MessageHandleContext(TMessage message, IServiceProvider serviceProvider)
    {
        Message = message;
        ServiceProvider = serviceProvider;
    }
}
