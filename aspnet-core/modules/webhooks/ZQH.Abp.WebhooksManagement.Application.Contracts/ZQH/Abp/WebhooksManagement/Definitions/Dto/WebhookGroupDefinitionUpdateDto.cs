using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace ZQH.Abp.WebhooksManagement.Definitions;

public class WebhookGroupDefinitionUpdateDto : WebhookGroupDefinitionCreateOrUpdateDto, IHasConcurrencyStamp
{
    [StringLength(40)]
    public string ConcurrencyStamp { get; set; }
}
