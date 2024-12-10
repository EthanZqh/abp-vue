﻿using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ZQH.Abp.OpenApi;

[Dependency(ServiceLifetime.Singleton, TryRegister = true)]
public class AlwaysAllowIpAddressChecker : IIpAddressChecker
{
    public Task<bool> IsGrantAsync(string ipAddress, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }
}
