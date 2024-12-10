using System;

namespace ZQH.Abp.DataProtection;
public class DataAccessKeywordContributorContext
{
    public IServiceProvider ServiceProvider { get; }
    public DataAccessKeywordContributorContext(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
}
