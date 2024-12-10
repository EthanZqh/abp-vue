using AutoMapper;
using ZQH.Abp.AuditLogging;

namespace ZQH.Abp.EntityChange;
public class AbpEntityChangeMapperProfile : Profile
{
    public AbpEntityChangeMapperProfile()
    {
        CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
        CreateMap<AuditLogging.EntityChange, EntityChangeDto>()
            .MapExtraProperties();
    }
}
