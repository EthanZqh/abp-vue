using System.Collections.Generic;

namespace ZQH.Abp.Localization.CultureMap;

public class AbpLocalizationCultureMapOptions
{
    public List<CultureMapInfo> CulturesMaps { get; }

    public List<CultureMapInfo> UiCulturesMaps { get; }

    public AbpLocalizationCultureMapOptions()
    {
        CulturesMaps = new List<CultureMapInfo>();
        UiCulturesMaps = new List<CultureMapInfo>();
    }
}
