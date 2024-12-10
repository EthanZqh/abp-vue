﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ZQH.Abp.Sonatype.Nexus.Components;

[Serializable]
public class NexusComponentListResult
{
    [JsonPropertyName("continuationToken")]
    public string ContinuationToken { get; set; }

    [JsonPropertyName("items")]
    public List<NexusComponent> Items { get; set; }

    public NexusComponentListResult()
    {
        Items = new List<NexusComponent>();
    }
}
