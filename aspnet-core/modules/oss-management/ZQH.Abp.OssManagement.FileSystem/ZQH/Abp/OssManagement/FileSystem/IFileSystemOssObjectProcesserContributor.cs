using System.Threading.Tasks;

namespace ZQH.Abp.OssManagement.FileSystem;

public interface IFileSystemOssObjectProcesserContributor
{
    Task ProcessAsync(FileSystemOssObjectContext context);
}
