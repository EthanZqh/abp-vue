﻿using System.Globalization;
using Volo.Abp.Users;

namespace ZQH.Abp.AspNetCore.Mvc.Client;

internal static class MvcCachedApplicationConfigurationClientHelper
{
    public static string CreateCacheKey(ICurrentUser currentUser)
    {
        var userKey = currentUser.Id?.ToString("N") ?? "Anonymous";
        return $"ApplicationConfiguration_{userKey}_{CultureInfo.CurrentUICulture.Name}";
    }
}
