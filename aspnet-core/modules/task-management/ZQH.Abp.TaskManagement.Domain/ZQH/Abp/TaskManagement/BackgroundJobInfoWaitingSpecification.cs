﻿using ZQH.Abp.BackgroundTasks;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ZQH.Abp.TaskManagement;

public class BackgroundJobInfoWaitingSpecification : Volo.Abp.Specifications.Specification<BackgroundJobInfo>
{
    public override Expression<Func<BackgroundJobInfo, bool>> ToExpression()
    {
        var status = new JobStatus[] { JobStatus.Queuing, JobStatus.FailedRetry };

        Expression<Func<BackgroundJobInfo, bool>> expression = _ => true;

        return expression
            .And(x => x.IsEnabled && !x.IsAbandoned)
            .And(x => x.JobType != JobType.Period && status.Contains(x.Status))
            .And(x => (x.MaxCount == 0 || x.TriggerCount < x.MaxCount) || (x.MaxTryCount == 0 || x.TryCount < x.MaxTryCount));
    }
}
