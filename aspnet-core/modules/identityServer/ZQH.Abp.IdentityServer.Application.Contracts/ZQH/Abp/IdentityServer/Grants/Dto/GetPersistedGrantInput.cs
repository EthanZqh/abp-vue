﻿using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.IdentityServer.Grants;

public class GetPersistedGrantInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
    public string SubjectId { get; set; }
}
