using Volo.Abp.Application.Services;

namespace ZQH.Abp.TaskManagement;

public interface IBackgroundJobLogAppService : 
    IReadOnlyAppService<
        BackgroundJobLogDto,
        long,
        BackgroundJobLogGetListInput>,
    IDeleteAppService<long>
{
}
