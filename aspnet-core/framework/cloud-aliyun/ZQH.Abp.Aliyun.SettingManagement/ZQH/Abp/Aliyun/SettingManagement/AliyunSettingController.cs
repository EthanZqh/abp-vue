﻿using ZQH.Abp.SettingManagement;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace ZQH.Abp.Aliyun.SettingManagement;

[RemoteService(Name = AbpSettingManagementRemoteServiceConsts.RemoteServiceName)]
[Area("settingManagement")]
[Route("api/setting-management/aliyun")]
public class AliyunSettingController : AbpControllerBase, IAliyunSettingAppService
{
    protected IAliyunSettingAppService AppService { get; }

    public AliyunSettingController(
        IAliyunSettingAppService appService)
    {
        AppService = appService;
    }

    [HttpGet]
    [Route("by-current-tenant")]
    public async virtual Task<SettingGroupResult> GetAllForCurrentTenantAsync()
    {
        return await AppService.GetAllForCurrentTenantAsync();
    }

    [HttpGet]
    [Route("by-global")]
    public async virtual Task<SettingGroupResult> GetAllForGlobalAsync()
    {
        return await AppService.GetAllForGlobalAsync();
    }
}
