using System;
using System.Text.Json.Serialization;

namespace ZQH.Abp.Sonatype.Nexus.Repositories;

[Serializable]
public abstract class NexusRepositoryCreateArgs
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("online")]
    public bool Online { get; set; }
}
