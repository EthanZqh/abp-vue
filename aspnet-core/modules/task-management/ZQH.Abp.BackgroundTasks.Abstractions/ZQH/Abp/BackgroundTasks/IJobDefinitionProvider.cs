namespace ZQH.Abp.BackgroundTasks;

public interface IJobDefinitionProvider
{
    void Define(IJobDefinitionContext context);
}
