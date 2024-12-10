﻿using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ZQH.Abp.MessageService.EntityFrameworkCore;

public class MessageServiceModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
{
    public MessageServiceModelBuilderConfigurationOptions(
        [NotNull] string tablePrefix = AbpMessageServiceDbProperties.DefaultTablePrefix,
        [CanBeNull] string schema = AbpMessageServiceDbProperties.DefaultSchema)
        : base(
            tablePrefix,
            schema)
    {

    }
}