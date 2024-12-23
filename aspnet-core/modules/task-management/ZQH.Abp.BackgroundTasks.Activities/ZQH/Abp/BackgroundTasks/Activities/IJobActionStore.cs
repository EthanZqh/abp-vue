﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ZQH.Abp.BackgroundTasks.Activities;

public interface IJobActionStore
{
    Task<List<JobAction>> GetActionsAsync(string id, CancellationToken cancellationToken = default);
}
