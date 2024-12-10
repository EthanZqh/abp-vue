using System.Collections.Generic;

namespace ZQH.Abp.CachingManagement;

public class CackeKeysResponse
{
    public string NextMarker { get; }

    public IEnumerable<string> Keys { get; }

    public CackeKeysResponse(
        string nextMarker,
        IEnumerable<string> keys)
    {
        NextMarker = nextMarker;
        Keys = keys;
    }
}
