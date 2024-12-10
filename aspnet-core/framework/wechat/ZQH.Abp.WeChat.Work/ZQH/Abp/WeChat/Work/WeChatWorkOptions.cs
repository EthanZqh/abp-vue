namespace ZQH.Abp.WeChat.Work;

public class WeChatWorkOptions
{
    public WeChatWorkApplicationConfigurationDictionary Applications { get; set; }

    public WeChatWorkOptions()
    {
        Applications = new WeChatWorkApplicationConfigurationDictionary();
    }
}
