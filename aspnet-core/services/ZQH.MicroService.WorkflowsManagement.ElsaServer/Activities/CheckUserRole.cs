using Elsa.Workflows.Models;
using Elsa.Workflows;
using Elsa.Extensions;

namespace Activities;

public class CheckUserRole : CodeActivity<string>
{
    //[ActivityInput(Hint = "Enter the role to check.")]
    //public string Role { get; set; }
    public Input<string> Role { get; set; } = default!;

    //protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
    protected override void Execute(ActivityExecutionContext context)
    {
        // Replace this with your actual role-checking logic.
        var role = Role.Get(context);


        //bool hasRole = CheckUserRoleLogic(context., Role);

        // Return an outcome based on whether the user has the role.

        context.SetResult("HasRole" + role);
        //return Outcome(hasRole ? "True" : "False");
    }

    //private bool CheckUserRoleLogic(IUser user, string role)
    //{
    //    // Implement your role-checking logic here.
    //    // This could involve checking against a database or an identity management system.
    //    return user.Roles.Contains(role);
    //}
}
