using AutoMapper;
using ZQH.Abp.Auditing.AuditLogs;
using ZQH.Abp.Auditing.Logging;
using ZQH.Abp.Auditing.SecurityLogs;
using ZQH.Abp.AuditLogging;
using ZQH.Abp.Logging;

namespace ZQH.Abp.Auditing;

public class AbpAuditingMapperProfile : Profile
{
    public AbpAuditingMapperProfile()
    {
        CreateMap<AuditLogAction, AuditLogActionDto>()
            .MapExtraProperties();
        CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
        CreateMap<EntityChangeWithUsername, EntityChangeWithUsernameDto>();
        CreateMap<EntityChange, EntityChangeDto>()
            .MapExtraProperties();
        CreateMap<AuditLog, AuditLogDto>()
            .MapExtraProperties();

        CreateMap<SecurityLog, SecurityLogDto>()
            .MapExtraProperties();

        CreateMap<LogField, LogFieldDto>();
        CreateMap<LogException, LogExceptionDto>();
        CreateMap<LogInfo, LogDto>();
    }
}
