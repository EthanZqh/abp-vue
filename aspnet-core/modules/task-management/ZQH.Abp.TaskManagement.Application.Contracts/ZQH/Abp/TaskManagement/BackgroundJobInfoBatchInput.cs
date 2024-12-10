using System;
using System.Collections.Generic;

namespace ZQH.Abp.TaskManagement;

public class BackgroundJobInfoBatchInput
{
    public List<string> JobIds { get; set; } = new List<string>();
}
