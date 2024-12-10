﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.SettingManagement;
using Volo.Abp.Validation;

namespace ZQH.Abp.SettingManagement;
public class SettingDefinitionCreateDto : SettingDefinitionCreateOrUpdateDto
{
    [Required]
    [DynamicStringLength(typeof(SettingDefinitionRecordConsts), nameof(SettingDefinitionRecordConsts.MaxNameLength))]
    public string Name { get; set; }
}
