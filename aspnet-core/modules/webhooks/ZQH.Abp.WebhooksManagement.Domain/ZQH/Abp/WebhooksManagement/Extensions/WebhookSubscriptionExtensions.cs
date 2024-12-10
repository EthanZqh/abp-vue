﻿using ZQH.Abp.Webhooks;
using Newtonsoft.Json;
using System.Linq;

namespace ZQH.Abp.WebhooksManagement.Extensions;

public static class WebhookSubscriptionExtensions
{
    public static string ToSubscribedWebhooksString(this WebhookSubscriptionInfo webhookSubscription)
    {
        if (webhookSubscription.Webhooks.Any())
        {
            return JsonConvert.SerializeObject(webhookSubscription.Webhooks);
        }

        return null;
    }

    public static string ToWebhookHeadersString(this WebhookSubscriptionInfo webhookSubscription)
    {
        if (webhookSubscription.Headers.Any())
        {
            return JsonConvert.SerializeObject(webhookSubscription.Headers);
        }

        return null;
    }
}
