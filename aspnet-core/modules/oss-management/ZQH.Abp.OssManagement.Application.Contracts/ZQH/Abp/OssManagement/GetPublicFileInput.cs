﻿using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.OssManagement;

public class GetPublicFileInput : GetFileMultiTenancyInput
{
    [Required]
    public string Name { get; set; }

    public string Path { get; set; }

    public string Process { get; set; }
}
