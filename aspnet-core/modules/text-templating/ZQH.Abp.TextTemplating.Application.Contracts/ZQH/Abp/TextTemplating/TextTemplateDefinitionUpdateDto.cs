using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.TextTemplating;
public class TextTemplateDefinitionUpdateDto : TextTemplateDefinitionCreateOrUpdateDto, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
