﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.FeatureManagement.Definitions;
public class FeatureDefinitionUpdateDto : FeatureDefinitionCreateOrUpdateDto, IHasConcurrencyStamp
{
    [StringLength(40)]
    public string ConcurrencyStamp { get; set; }
}
