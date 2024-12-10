using Volo.Abp.Validation;

namespace ZQH.Abp.TextTemplating;

public class TextTemplateRestoreInput
{
    [DynamicStringLength(typeof(TextTemplateConsts), nameof(TextTemplateConsts.MaxCultureLength))]
    public string Culture { get; set; }
}
