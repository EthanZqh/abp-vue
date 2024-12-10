using System;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.IdentityServer.ApiScopes;

public interface IApiScopeAppService : 
    ICrudAppService<
        ApiScopeDto,
        Guid,
        GetApiScopeInput,
        ApiScopeCreateDto,
        ApiScopeUpdateDto>
{
}
