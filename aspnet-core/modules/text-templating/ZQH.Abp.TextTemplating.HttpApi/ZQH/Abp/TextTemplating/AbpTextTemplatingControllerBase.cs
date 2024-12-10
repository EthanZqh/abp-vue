﻿using ZQH.Abp.TextTemplating.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ZQH.Abp.TextTemplating;

public abstract class AbpTextTemplatingControllerBase : AbpControllerBase
{
    protected AbpTextTemplatingControllerBase()
    {
        LocalizationResource = typeof(AbpTextTemplatingResource);
    }
}
