﻿using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.Identity;

public class OrganizationUnitGetUnaddedUserByPagedDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
