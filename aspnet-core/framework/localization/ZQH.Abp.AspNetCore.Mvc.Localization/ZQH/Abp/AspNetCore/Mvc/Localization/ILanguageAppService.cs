﻿using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.AspNetCore.Mvc.Localization;

public interface ILanguageAppService : IApplicationService
{
    Task<ListResultDto<LanguageDto>> GetListAsync(GetLanguageWithFilterDto input);
}
