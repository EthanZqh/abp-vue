using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace ZQH.Abp.Localization.CultureMap;

[DependsOn(typeof(AbpAspNetCoreModule))]
public class AbpLocalizationCultureMapModule : AbpModule
{
}
