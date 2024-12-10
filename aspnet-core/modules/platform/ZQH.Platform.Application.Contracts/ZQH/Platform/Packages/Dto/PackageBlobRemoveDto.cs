﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace ZQH.Platform.Packages;

public class PackageBlobRemoveDto
{
    [Required]
    [DynamicMaxLength(typeof(PackageBlobConsts), nameof(PackageBlobConsts.MaxNameLength))]
    public string Name { get; set; }
}
