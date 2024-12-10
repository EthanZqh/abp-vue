﻿using ZQH.Abp.Location.Tencent.Model;
using Newtonsoft.Json;

namespace ZQH.Abp.Location.Tencent.Response;

public class TencentGeocodeResponse : TencentLocationResponse
{
    /// <summary>
    /// 地址解析结果
    /// </summary>
    [JsonProperty("result")]
    public TencentGeocode Result { get; set; } = new TencentGeocode();
}
