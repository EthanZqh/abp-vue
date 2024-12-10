using ZQH.Abp.TaskManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ZQH.Abp.TaskManagement;

public abstract class TaskManagementController : AbpControllerBase
{
    protected TaskManagementController()
    {
        LocalizationResource = typeof(TaskManagementResource);
    }
}
