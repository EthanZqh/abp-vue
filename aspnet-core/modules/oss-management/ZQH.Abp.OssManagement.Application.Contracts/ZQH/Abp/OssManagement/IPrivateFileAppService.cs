using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.OssManagement;

public interface IPrivateFileAppService : IFileAppService
{
    Task<FileShareDto> ShareAsync(FileShareInput input);

    Task<ListResultDto<MyFileShareDto>> GetShareListAsync();
}
