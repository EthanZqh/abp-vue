using Volo.Abp.Application.Dtos;

namespace ZQH.MicroService.Workflows.ElsaHttpApi.Host.ElsaHttpApi.Host;

public class OnboardingGetListInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
