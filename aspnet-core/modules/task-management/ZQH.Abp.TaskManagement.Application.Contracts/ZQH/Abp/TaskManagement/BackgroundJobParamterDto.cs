﻿namespace ZQH.Abp.TaskManagement;

public class BackgroundJobParamterDto
{
    public string Name { get; set; }

    public bool Required { get; set; }

    public string DisplayName { get; set; }

    public string Description { get; set; }
}
