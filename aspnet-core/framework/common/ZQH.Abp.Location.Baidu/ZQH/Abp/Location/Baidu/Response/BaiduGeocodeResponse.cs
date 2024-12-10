using ZQH.Abp.Location.Baidu.Model;

namespace ZQH.Abp.Location.Baidu.Response;

public class BaiduGeocodeResponse : BaiduLocationResponse
{
    public BaiduGeocode Result { get; set; } = new BaiduGeocode();
}
