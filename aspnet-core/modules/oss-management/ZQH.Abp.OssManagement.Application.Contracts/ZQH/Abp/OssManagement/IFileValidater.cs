using System.Threading.Tasks;

namespace ZQH.Abp.OssManagement;

public interface IFileValidater
{
    Task ValidationAsync(UploadFile input);
}
