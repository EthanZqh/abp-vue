using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using ZQH.Abp.Onboarding;
using ZQH.Abp.Onboarding.Definitions.Dto;
using ZQH.Abp.Onboarding.Models;
using ZQH.Abp.Onboarding.Services;

namespace ZQH.Abp.Onboarding;
[Controller]
[Route("api/workflow/onboarding")]
public class OnboardingController : OnboardingControllerBase, IOnboardingAppService
{
    protected IOnboardingAppService OnboardingAppService { get; }

    public OnboardingController(IOnboardingAppService onboardingAppService)
    {
        OnboardingAppService = onboardingAppService;
    }
    [HttpGet]
    public virtual Task<ListResultDto<OnboardingTaskDto>> GetListAsync(OnboardingGetListInput input)
    {
        return OnboardingAppService.GetListAsync(input);
    }
    [HttpPost("run-task")]
    public async Task<OnboardingTaskDto> CreateAsync(WebhookEvent webhookEvent)
    {
        return await OnboardingAppService.CreateAsync(webhookEvent);
    }
    //[HttpPut]
    //[Route("{taskId}")]
    //public async Task<OnboardingTaskDto> CompleteTaskAsync(int taskId)
    //{
    //    return await OnboardingAppService.CompleteTaskAsync(taskId);
    //}
    [HttpPut]
    [Route("{taskId}")]
    public async Task<OnboardingTaskDto> CompleteTaskAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await OnboardingAppService.CompleteTaskAsync(taskId, cancellationToken);
    }

}
