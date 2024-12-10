using Volo.Abp.BlobStoring;

namespace ZQH.Abp.BlobStoring.Tencent;

public interface ITencentBlobNameCalculator
{
    string Calculate(BlobProviderArgs args);
}
