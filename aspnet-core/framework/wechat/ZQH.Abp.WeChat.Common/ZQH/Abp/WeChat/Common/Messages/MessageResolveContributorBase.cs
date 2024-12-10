﻿using System.Threading.Tasks;

namespace ZQH.Abp.WeChat.Common.Messages;
public abstract class MessageResolveContributorBase : IMessageResolveContributor
{
    public abstract string Name { get; }

    public abstract Task ResolveAsync(IMessageResolveContext context);
}
