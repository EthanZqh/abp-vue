using ZQH.Abp.Location.Baidu.Model;

namespace ZQH.Abp.Location.Baidu.Response;

public class BaiduReGeocodeResponse : BaiduLocationResponse
{
    public BaiduReGeocode Result { get; set; } = new BaiduReGeocode();
}
