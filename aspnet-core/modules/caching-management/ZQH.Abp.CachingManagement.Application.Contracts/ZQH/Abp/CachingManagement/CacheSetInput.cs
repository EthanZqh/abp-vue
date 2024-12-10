﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.CachingManagement;
public class CacheSetInput
{
    [Required]
    public string Key { get; set; }
    public string Value { get; set; }
    public DateTime? AbsoluteExpiration { get; set; }
    public DateTime? SlidingExpiration { get; set; }
}