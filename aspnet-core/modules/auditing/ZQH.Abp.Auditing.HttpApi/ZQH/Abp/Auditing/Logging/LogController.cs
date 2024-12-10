﻿using Asp.Versioning;
using ZQH.Abp.Auditing.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace ZQH.Abp.Auditing.Logging;

[RemoteService(Name = AuditingRemoteServiceConsts.RemoteServiceName)]
[Area("auditing")]
[ControllerName("logging")]
[Route("api/auditing/logging")]
[Authorize(AuditingPermissionNames.SystemLog.Default)]
public class LogController : AbpControllerBase, ILogAppService
{
    private readonly ILogAppService _service;

    public LogController(ILogAppService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id}")]
    public async virtual Task<LogDto> GetAsync(string id)
    {
        return await _service.GetAsync(id);
    }

    [HttpGet]
    public async virtual Task<PagedResultDto<LogDto>> GetListAsync(LogGetByPagedDto input)
    {
        return await _service.GetListAsync(input);
    }
}