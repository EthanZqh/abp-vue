using Volo.Abp.Application.Dtos;

namespace ZQH.Abp.MessageService.Chat;

public class GetMyFriendsDto : ISortedResultRequest
{
    public string Sorting { get; set; }
}
