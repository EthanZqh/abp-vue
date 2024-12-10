using System.Threading.Tasks;

namespace ZQH.Abp.OssManagement;
public interface IOssObjectExpireor
{
    Task ExpireAsync(ExprieOssObjectRequest request);
}
