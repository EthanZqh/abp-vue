﻿namespace ZQH.Abp.Features.LimitValidation.Redis;

public interface IRedisLimitFeatureNamingNormalizer
{
    string NormalizeFeatureName(string instance, RequiresLimitFeatureContext context);
}
