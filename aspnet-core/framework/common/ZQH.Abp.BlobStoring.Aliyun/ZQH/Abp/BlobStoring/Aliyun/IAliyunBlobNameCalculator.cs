using Volo.Abp.BlobStoring;

namespace ZQH.Abp.BlobStoring.Aliyun;

public interface IAliyunBlobNameCalculator
{
    string Calculate(BlobProviderArgs args);
}
