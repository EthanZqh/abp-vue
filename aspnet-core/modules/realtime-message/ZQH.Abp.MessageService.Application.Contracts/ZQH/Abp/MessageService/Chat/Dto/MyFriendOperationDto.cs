using System;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.MessageService.Chat;

public class MyFriendOperationDto
{
    [Required]
    public Guid FriendId { get; set; }
}
