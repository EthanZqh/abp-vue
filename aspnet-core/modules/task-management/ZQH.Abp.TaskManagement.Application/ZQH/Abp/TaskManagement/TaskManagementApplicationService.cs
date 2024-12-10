using ZQH.Abp.TaskManagement.Localization;
using Volo.Abp.Application.Services;

namespace ZQH.Abp.TaskManagement;

public abstract class TaskManagementApplicationService : ApplicationService
{
    protected TaskManagementApplicationService()
    {
        LocalizationResource = typeof(TaskManagementResource);
        ObjectMapperContext = typeof(TaskManagementApplicationModule);
    }
}
