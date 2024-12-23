﻿using System.Collections.Generic;

namespace ZQH.Abp.WebhooksManagement;

public class WebhookAvailableGroupDto
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public List<WebhookAvailableDto> Webhooks { get; set; } = new List<WebhookAvailableDto>();
}
