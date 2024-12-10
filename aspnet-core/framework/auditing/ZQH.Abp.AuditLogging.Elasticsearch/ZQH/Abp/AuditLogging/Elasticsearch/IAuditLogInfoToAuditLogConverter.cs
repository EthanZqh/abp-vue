using System.Threading.Tasks;
using Volo.Abp.Auditing;

namespace ZQH.Abp.AuditLogging;

public interface IAuditLogInfoToAuditLogConverter
{
    Task<AuditLog> ConvertAsync(AuditLogInfo auditLogInfo);
}
