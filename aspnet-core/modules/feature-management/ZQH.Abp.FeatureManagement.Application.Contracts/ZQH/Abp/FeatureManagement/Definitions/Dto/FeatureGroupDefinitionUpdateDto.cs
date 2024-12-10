﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.FeatureManagement.Definitions;
public class FeatureGroupDefinitionUpdateDto : FeatureGroupDefinitionCreateOrUpdateDto, IHasConcurrencyStamp
{
    [StringLength(40)]
    public string ConcurrencyStamp { get; set; }
}
