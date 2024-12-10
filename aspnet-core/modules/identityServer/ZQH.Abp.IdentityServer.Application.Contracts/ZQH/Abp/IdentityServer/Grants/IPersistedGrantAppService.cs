using System;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.IdentityServer.Grants;

public interface IPersistedGrantAppService : 
    IReadOnlyAppService<PersistedGrantDto, Guid, GetPersistedGrantInput>,
    IDeleteAppService<Guid>
{

}
