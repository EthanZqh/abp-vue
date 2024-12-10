using System;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.OpenIddict.Authorizations;

public interface IOpenIddictAuthorizationAppService :
    IReadOnlyAppService<
        OpenIddictAuthorizationDto,
        Guid,
        OpenIddictAuthorizationGetListInput>,
    IDeleteAppService<Guid>
{
}
