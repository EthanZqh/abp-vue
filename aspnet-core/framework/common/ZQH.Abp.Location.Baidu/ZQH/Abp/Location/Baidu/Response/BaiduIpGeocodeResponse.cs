using ZQH.Abp.Location.Baidu.Model;

namespace ZQH.Abp.Location.Baidu.Response;

public class BaiduIpGeocodeResponse : BaiduLocationResponse
{
    public string Address { get; set; }

    public Content Content { get; set; } = new Content();
}
