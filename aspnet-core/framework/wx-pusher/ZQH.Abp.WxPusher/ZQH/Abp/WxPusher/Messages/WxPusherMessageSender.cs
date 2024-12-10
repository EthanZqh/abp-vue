﻿using ZQH.Abp.Features.LimitValidation;
using ZQH.Abp.WxPusher.Features;
using ZQH.Abp.WxPusher.Token;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Features;

namespace ZQH.Abp.WxPusher.Messages;

[RequiresFeature(WxPusherFeatureNames.Enable)]
public class WxPusherMessageSender : WxPusherRequestProvider, IWxPusherMessageSender
{
    protected IWxPusherTokenProvider WxPusherTokenProvider { get; }

    public WxPusherMessageSender(IWxPusherTokenProvider wxPusherTokenProvider)
    {
        WxPusherTokenProvider = wxPusherTokenProvider;
    }

    [RequiresFeature(WxPusherFeatureNames.Message.Enable)]
    [RequiresLimitFeature(
        WxPusherFeatureNames.Message.SendLimit,
        WxPusherFeatureNames.Message.SendLimitInterval,
        LimitPolicy.Days)]
    public async virtual Task<List<SendMessageResult>> SendAsync(
        string content, 
        string summary = "", 
        MessageContentType contentType = MessageContentType.Text, 
        List<int> topicIds = null, 
        List<string> uids = null,
        string url = "",
        CancellationToken cancellationToken = default)
    {
        var token = await WxPusherTokenProvider.GetTokenAsync(cancellationToken);
        var client = HttpClientFactory.GetWxPusherClient();
        var sendMessage = new SendMessage(
            token,
            content,
            summary,
            contentType,
            url);
        if (topicIds != null)
        {
            sendMessage.TopicIds.AddIfNotContains(topicIds);
        }
        if (uids != null)
        {
            sendMessage.Uids.AddIfNotContains(uids);
        }

        var resultContent = await client.SendMessageAsync(
            sendMessage,
            cancellationToken);

        var response = JsonSerializer
            .Deserialize<WxPusherResult<List<SendMessageResult>>>(resultContent);

        return response.GetData();
    }
}
