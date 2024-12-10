using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using ZQH.Abp.Onboarding.Definitions.Dto;
using ZQH.Abp.Onboarding.Models;
using ZQH.Abp.Onboarding.Services;

namespace ZQH.Abp.Onboarding;
public interface  IOnboardingAppService : IApplicationService
{
    //Task<FeatureDefinitionDto> GetAsync(string name);

    //Task DeleteAsync(string name);

    //Task<FeatureDefinitionDto> UpdateAsync(string name, FeatureDefinitionUpdateDto input);

    Task<ListResultDto<OnboardingTaskDto>> GetListAsync(OnboardingGetListInput input);


    Task<OnboardingTaskDto> CreateAsync(WebhookEvent webhookEvent);

    Task<OnboardingTaskDto> CompleteTaskAsync(Guid taskId,CancellationToken cancellationToken);

    

}
