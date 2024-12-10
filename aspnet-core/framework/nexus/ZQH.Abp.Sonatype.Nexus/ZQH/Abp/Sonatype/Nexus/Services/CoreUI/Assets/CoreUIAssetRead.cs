using System.Collections.Generic;

namespace ZQH.Abp.Sonatype.Nexus.Services.CoreUI.Assets;
public class CoreUIAssetRead : List<string>
{
    public CoreUIAssetRead(
        string assetId,
        string repository)
    {
        Add(assetId);
        Add(repository);
    }
}
