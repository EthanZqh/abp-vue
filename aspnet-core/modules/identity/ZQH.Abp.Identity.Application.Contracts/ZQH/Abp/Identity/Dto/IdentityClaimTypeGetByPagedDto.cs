﻿using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Identity;

public class IdentityClaimTypeGetByPagedDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}