using System;

namespace ZQH.Abp.WeChat;

[Serializable]
public abstract class WeChatRequest
{
    public virtual string SerializeToJson()
    {
        return WeChatObjectSerializeExtensions.SerializeToJson(this);
    }
}
