﻿using System;
using Volo.Abp.EventBus;

namespace ZQH.Abp.BackgroundTasks.EventBus;

[Serializable]
[EventName("abp.background-tasks.job.stop")]
public class JobStopEventData : JobEventData
{
}