using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Onboarding.Definitions.Dto;

public class OnboardingGetListInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
