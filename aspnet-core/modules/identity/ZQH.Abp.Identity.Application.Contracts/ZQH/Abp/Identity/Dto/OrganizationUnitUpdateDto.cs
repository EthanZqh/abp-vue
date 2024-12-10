using Volo.Abp.ObjectExtending;

namespace ZQH.Abp.Identity;

public class OrganizationUnitUpdateDto : ExtensibleObject
{
    public string DisplayName { get; set; }
}
