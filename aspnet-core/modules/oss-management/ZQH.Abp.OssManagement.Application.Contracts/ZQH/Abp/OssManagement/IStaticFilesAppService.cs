using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace ZQH.Abp.OssManagement;

public interface IStaticFilesAppService: IApplicationService
{
    Task<IRemoteStreamContent> GetAsync(GetStaticFileInput input);
}
