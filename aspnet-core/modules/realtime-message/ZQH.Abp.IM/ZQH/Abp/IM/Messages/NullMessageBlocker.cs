﻿using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ZQH.Abp.IM.Messages;

[Dependency(TryRegister = true)]
public class NullMessageBlocker : IMessageBlocker, ISingletonDependency
{
    public Task InterceptAsync(ChatMessage message)
    {
        return Task.CompletedTask;
    }
}
