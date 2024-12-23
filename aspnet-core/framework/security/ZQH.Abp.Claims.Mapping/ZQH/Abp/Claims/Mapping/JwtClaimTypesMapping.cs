﻿using IdentityModel;
using Volo.Abp.Security.Claims;

namespace ZQH.Abp.Claims.Mapping;

public static class JwtClaimTypesMapping
{
    public static void MapAbpClaimTypes()
    {
        AbpClaimTypes.UserId = JwtClaimTypes.Subject;
        AbpClaimTypes.Role = JwtClaimTypes.Role;
        AbpClaimTypes.UserName = JwtClaimTypes.PreferredUserName;
        AbpClaimTypes.Name = JwtClaimTypes.GivenName;
        AbpClaimTypes.SurName = JwtClaimTypes.FamilyName;
        AbpClaimTypes.PhoneNumber = JwtClaimTypes.PhoneNumber;
        AbpClaimTypes.PhoneNumberVerified = JwtClaimTypes.PhoneNumberVerified;
        AbpClaimTypes.Email = JwtClaimTypes.Email;
        AbpClaimTypes.EmailVerified = JwtClaimTypes.EmailVerified;
        AbpClaimTypes.ClientId = JwtClaimTypes.ClientId;
    }
}
