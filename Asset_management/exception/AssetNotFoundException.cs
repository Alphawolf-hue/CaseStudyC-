using System;

namespace DigitalAssetManagement.exception
{
    public class AssetNotFoundException : Exception
    {
        public AssetNotFoundException() : base("Asset not found.") { }

        public AssetNotFoundException(string message) : base(message) { }

        public AssetNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
