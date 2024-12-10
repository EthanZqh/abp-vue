﻿using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.OpenApi;

public interface IAppKeyStore
{
    Task<AppDescriptor> FindAsync(string appKey, CancellationToken cancellationToken = default);

    Task StoreAsync(AppDescriptor descriptor, CancellationToken cancellationToken = default);
}
