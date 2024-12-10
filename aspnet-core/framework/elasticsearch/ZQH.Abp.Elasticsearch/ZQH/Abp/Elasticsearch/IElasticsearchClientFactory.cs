using Nest;

namespace ZQH.Abp.Elasticsearch
{
    public interface IElasticsearchClientFactory
    {
        IElasticClient Create();
    }
}
