﻿using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.Rules;

public interface IRuleContributor
{
    void Initialize(RulesInitializationContext context);

    Task ExecuteAsync<T>(T input, object[] @params = null, CancellationToken cancellationToken = default);

    void Shutdown();
}
