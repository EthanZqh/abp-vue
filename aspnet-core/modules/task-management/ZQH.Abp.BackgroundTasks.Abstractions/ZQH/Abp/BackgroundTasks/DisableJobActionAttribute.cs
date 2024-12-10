using System;

namespace ZQH.Abp.BackgroundTasks;
/// <summary>
/// 禁用作业调度行为
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DisableJobActionAttribute : Attribute
{
}
