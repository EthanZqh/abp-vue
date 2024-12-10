using AutoMapper;
using ZQH.Abp.Onboarding.Definitions.Dto;
using ZQH.Abp.Onboarding.Entities;

namespace ZQH.Abp.Onboarding;

public class OnboardingApplicationMappingProfile : Profile
{
    public OnboardingApplicationMappingProfile()
    {
        CreateMap<OnboardingTask, OnboardingTaskDto>();

    }
}
