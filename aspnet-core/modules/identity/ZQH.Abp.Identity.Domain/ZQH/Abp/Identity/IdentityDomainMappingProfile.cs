using AutoMapper;
using Volo.Abp.Identity;

namespace ZQH.Abp.Identity;

public class IdentityDomainMappingProfile : Profile
{
    public IdentityDomainMappingProfile()
    {
        CreateMap<IdentitySession, IdentitySessionEto>();
    }
}
