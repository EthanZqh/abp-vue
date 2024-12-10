﻿using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Users;

namespace ZQH.Abp.DataProtection.Subjects;

public class DataAccessUserIdContributor : IDataAccessSubjectContributor
{
    public string Name => UserPermissionValueProvider.ProviderName;

    public virtual List<DataAccessFilterGroup> GetFilterGroups(DataAccessSubjectContributorContext context)
    {
        var groups = new List<DataAccessFilterGroup>();
        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        if (currentUser.IsAuthenticated)
        {
            var resourceStore = context.ServiceProvider.GetRequiredService<IDataProtectedResourceStore>();
            var resource = resourceStore.Get(Name, currentUser.Id.ToString(), context.EntityTypeFullName, context.Operation);
            if (resource?.FilterGroup != null)
            {
                groups.Add(resource.FilterGroup);
            }
        }
        return groups;
    }

    public virtual List<string> GetAllowProperties(DataAccessSubjectContributorContext context)
    {
        var allowProperties = new List<string>();
        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        if (currentUser.IsAuthenticated)
        {
            var resourceStore = context.ServiceProvider.GetRequiredService<IDataProtectedResourceStore>();
            var resource = resourceStore.Get(Name, currentUser.Id.ToString(), context.EntityTypeFullName, context.Operation);
            if (resource?.AllowProperties.Any() == true)
            {
                allowProperties.AddIfNotContains(resource.AllowProperties);
            }
        }
        return allowProperties;
    }
}
