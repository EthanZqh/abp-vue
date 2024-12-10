﻿using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ZQH.Abp.Notifications.EntityFrameworkCore;

public class AbpNotificationsModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
{
    public AbpNotificationsModelBuilderConfigurationOptions(
        [NotNull] string tablePrefix = AbpNotificationsDbProperties.DefaultTablePrefix,
        [CanBeNull] string schema = AbpNotificationsDbProperties.DefaultSchema)
        : base(
            tablePrefix,
            schema)
    {

    }
}
