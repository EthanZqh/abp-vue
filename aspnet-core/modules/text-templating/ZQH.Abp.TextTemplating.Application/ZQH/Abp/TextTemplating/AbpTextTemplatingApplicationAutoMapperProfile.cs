using AutoMapper;

namespace ZQH.Abp.TextTemplating;

public class AbpTextTemplatingApplicationAutoMapperProfile : Profile
{
    public AbpTextTemplatingApplicationAutoMapperProfile()
    {
        CreateMap<TextTemplateDefinition, TextTemplateDefinitionDto>();
    }
}
