﻿using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ZQH.Abp.TaskManagement.EntityFrameworkCore;

public class TaskManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
{
    public TaskManagementModelBuilderConfigurationOptions(
        [NotNull] string tablePrefix = "",
        [CanBeNull] string schema = null)
        : base(
            tablePrefix,
            schema)
    {

    }
}
