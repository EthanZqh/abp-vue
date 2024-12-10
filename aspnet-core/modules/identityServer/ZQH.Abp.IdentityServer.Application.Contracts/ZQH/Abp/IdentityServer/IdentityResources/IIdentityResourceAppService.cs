using System;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.IdentityServer.IdentityResources;

public interface IIdentityResourceAppService : 
    ICrudAppService<
        IdentityResourceDto,
        Guid,
        IdentityResourceGetByPagedDto,
        IdentityResourceCreateOrUpdateDto,
        IdentityResourceCreateOrUpdateDto
        >
{
}
