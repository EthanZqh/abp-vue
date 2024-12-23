﻿namespace ZQH.Abp.Logging.Serilog.Elasticsearch;

public class AbpLoggingSerilogElasticsearchOptions
{
    public string IndexFormat { get; set; }

    public AbpLoggingSerilogElasticsearchOptions()
    {
        IndexFormat = "logstash-{0:yyyy.MM.dd}";
    }
}
