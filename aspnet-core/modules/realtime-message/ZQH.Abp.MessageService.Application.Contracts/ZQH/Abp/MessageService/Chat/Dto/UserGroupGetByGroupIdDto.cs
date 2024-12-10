using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.MessageService.Chat;

public class UserGroupGetByGroupIdDto
{
    [Required]
    public long GroupId { get; set; }
}
