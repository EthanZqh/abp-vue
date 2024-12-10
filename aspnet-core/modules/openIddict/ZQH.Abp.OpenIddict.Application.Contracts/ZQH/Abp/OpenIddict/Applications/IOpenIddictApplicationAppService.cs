using System;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.OpenIddict.Applications;

public interface IOpenIddictApplicationAppService : 
    ICrudAppService<
        OpenIddictApplicationDto,
        Guid,
        OpenIddictApplicationGetListInput,
        OpenIddictApplicationCreateDto,
        OpenIddictApplicationUpdateDto>
{
}
