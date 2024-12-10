using AutoMapper;

namespace ZQH.Abp.AuditLogging.EntityFrameworkCore;

public class AbpAuditingMapperProfile : Profile
{
    public AbpAuditingMapperProfile()
    {
        CreateMap<Volo.Abp.AuditLogging.AuditLogAction, ZQH.Abp.AuditLogging.AuditLogAction>()
            .MapExtraProperties();
        CreateMap<Volo.Abp.AuditLogging.EntityPropertyChange, ZQH.Abp.AuditLogging.EntityPropertyChange>();
        CreateMap<Volo.Abp.AuditLogging.EntityChange, ZQH.Abp.AuditLogging.EntityChange>()
            .MapExtraProperties();
        CreateMap<Volo.Abp.AuditLogging.AuditLog, ZQH.Abp.AuditLogging.AuditLog>()
            .MapExtraProperties();

        CreateMap<Volo.Abp.Identity.IdentitySecurityLog, ZQH.Abp.AuditLogging.SecurityLog>()
            .MapExtraProperties();
    }
}
