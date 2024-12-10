using System;

namespace ZQH.Abp.BackgroundTasks;
public interface IJobExceptionTypeFinder
{
    JobExceptionType GetExceptionType(JobEventContext eventContext, Exception exception);
}

