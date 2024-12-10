using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.SettingManagement;

public interface IReadonlySettingAppService : IApplicationService
{
    Task<SettingGroupResult> GetAllForGlobalAsync();

    Task<SettingGroupResult> GetAllForCurrentTenantAsync();
}
