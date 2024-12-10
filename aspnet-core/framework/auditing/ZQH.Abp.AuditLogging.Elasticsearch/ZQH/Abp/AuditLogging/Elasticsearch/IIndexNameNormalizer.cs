namespace ZQH.Abp.AuditLogging.Elasticsearch;

public interface IIndexNameNormalizer
{
    string NormalizeIndex(string index);
}
