using System;

namespace ZQH.Abp.WeChat.Work;

[Serializable]
public abstract class WeChatWorkRequest
{
    public virtual string SerializeToJson()
    {
        return WeChatObjectSerializeExtensions.SerializeToJson(this);
    }
}
