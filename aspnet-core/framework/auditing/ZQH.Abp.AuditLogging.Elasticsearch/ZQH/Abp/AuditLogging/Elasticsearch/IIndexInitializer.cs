using System.Threading.Tasks;

namespace ZQH.Abp.AuditLogging.Elasticsearch;

public interface IIndexInitializer
{
    Task InitializeAsync();
}
