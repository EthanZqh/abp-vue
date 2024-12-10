using AutoMapper;
using ZQH.Abp.BackgroundTasks;

namespace ZQH.Abp.TaskManagement;

public class TaskManagementDomainMapperProfile : Profile
{
    public TaskManagementDomainMapperProfile()
    {
        CreateMap<BackgroundJobInfo, JobInfo>();
        CreateMap<BackgroundJobInfo, BackgroundJobEto>();
    }
}
