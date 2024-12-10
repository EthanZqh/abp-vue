using Elsa.Workflows.Models;
using Elsa.Workflows;
using Elsa.Extensions;

namespace Activities;

public class Greeter : CodeActivity<string>
{
    public Input<string> Name1 { get; set; } = default!;
    protected override void Execute(ActivityExecutionContext context)
    {
        var name = Name1.Get(context);
        var message = $"Hello, {name}!";
        context.SetResult(message);
    }
}
