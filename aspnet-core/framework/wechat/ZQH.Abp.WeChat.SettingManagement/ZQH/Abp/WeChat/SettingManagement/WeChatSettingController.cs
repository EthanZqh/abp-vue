﻿using ZQH.Abp.SettingManagement;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace ZQH.Abp.WeChat.SettingManagement;

[RemoteService(Name = AbpSettingManagementRemoteServiceConsts.RemoteServiceName)]
[Area("settingManagement")]
[Route("api/wechat/setting-management")]
public class WeChatSettingController : AbpControllerBase, IWeChatSettingAppService
{
    protected IWeChatSettingAppService WeChatSettingAppService { get; }

    public WeChatSettingController(
        IWeChatSettingAppService weChatSettingAppService)
    {
        WeChatSettingAppService = weChatSettingAppService;
    }

    [HttpGet]
    [Route("by-current-tenant")]
    public async virtual Task<SettingGroupResult> GetAllForCurrentTenantAsync()
    {
        return await WeChatSettingAppService.GetAllForCurrentTenantAsync();
    }

    [HttpGet]
    [Route("by-global")]
    public async virtual Task<SettingGroupResult> GetAllForGlobalAsync()
    {
        return await WeChatSettingAppService.GetAllForGlobalAsync();
    }
}
