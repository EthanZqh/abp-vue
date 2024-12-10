using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Users;

namespace ZQH.Abp.DataProtection.Keywords;
public class DataAccessCurrentUserContributor : IDataAccessKeywordContributor
{
    public const string Name = "@CurrentUser";
    public string Keyword => Name;

    public object Contribute(DataAccessKeywordContributorContext context)
    {
        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        return currentUser.Id;
    }
}
