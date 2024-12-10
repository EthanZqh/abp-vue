using COSXML;
using System.Threading.Tasks;

namespace ZQH.Abp.BlobStoring.Tencent;

public interface ICosClientFactory
{
    Task<CosXml> CreateAsync<TContainer>();

    Task<CosXml> CreateAsync(TencentBlobProviderConfiguration configuration);
}
