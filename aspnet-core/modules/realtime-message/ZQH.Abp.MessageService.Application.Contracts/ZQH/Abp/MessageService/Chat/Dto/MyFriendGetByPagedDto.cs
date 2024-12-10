﻿using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.MessageService.Chat;

public class MyFriendGetByPagedDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}

public class MyLastContractFriendGetByPagedDto : PagedResultRequestDto
{
}
