﻿namespace ZQH.Abp.IdentityServer.ApiResources;

public class ApiResourceSecretCreateOrUpdateDto : SecretDto
{
    public HashType HashType { get; set; }
}
