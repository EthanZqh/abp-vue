using System;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.Saas.Editions;

public interface IEditionAppService :
    ICrudAppService<
        EditionDto,
        Guid,
        EditionGetListInput,
        EditionCreateDto,
        EditionUpdateDto>
{
}
