using System;

namespace UniPage
{
    public class PageAssetAttribute : Attribute
    {
        public string AssetLocation { get; }

        public PageAssetAttribute(string assetLocation)
        {
            AssetLocation = assetLocation;
        }
    }
}