using System.Threading.Tasks;

namespace ZQH.Abp.Rules.RulesEngine;

public interface IWorkflowsResolveContributor
{
    string Name { get; }

    Task ResolveAsync(IWorkflowsResolveContext context);

    void Initialize(RulesInitializationContext context);

    void Shutdown();
}
