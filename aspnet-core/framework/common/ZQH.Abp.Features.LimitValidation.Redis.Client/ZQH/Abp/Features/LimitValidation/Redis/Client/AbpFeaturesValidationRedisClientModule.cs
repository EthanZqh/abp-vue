using Volo.Abp.Modularity;

namespace ZQH.Abp.Features.LimitValidation.Redis.Client;

[DependsOn(typeof(AbpFeaturesValidationRedisModule))]
public class AbpFeaturesValidationRedisClientModule : AbpModule
{
}
