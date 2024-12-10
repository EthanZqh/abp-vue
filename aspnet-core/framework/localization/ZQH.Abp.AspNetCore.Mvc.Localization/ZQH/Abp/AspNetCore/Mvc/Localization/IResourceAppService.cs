﻿using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.AspNetCore.Mvc.Localization;

public interface IResourceAppService : IApplicationService
{
    Task<ListResultDto<ResourceDto>> GetListAsync(GetResourceWithFilterDto input);
}
