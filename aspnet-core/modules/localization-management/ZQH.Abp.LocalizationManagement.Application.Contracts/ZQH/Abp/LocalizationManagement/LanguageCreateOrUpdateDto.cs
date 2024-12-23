﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace ZQH.Abp.LocalizationManagement;
public abstract class LanguageCreateOrUpdateDto
{
    [Required]
    [DynamicStringLength(typeof(LanguageConsts), nameof(LanguageConsts.MaxDisplayNameLength))]
    public string DisplayName { get; set; }

    [DynamicStringLength(typeof(LanguageConsts), nameof(LanguageConsts.MaxTwoLetterISOLanguageNameLength))]
    public string FlagIcon { get; set; }
}
