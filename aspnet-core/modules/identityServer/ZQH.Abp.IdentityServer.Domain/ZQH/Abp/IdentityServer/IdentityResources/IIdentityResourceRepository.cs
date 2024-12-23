﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.IdentityServer.IdentityResources;

public interface IIdentityResourceRepository : Volo.Abp.IdentityServer.IdentityResources.IIdentityResourceRepository
{
    Task<List<string>> GetNamesAsync(CancellationToken cancellationToken = default);
}
