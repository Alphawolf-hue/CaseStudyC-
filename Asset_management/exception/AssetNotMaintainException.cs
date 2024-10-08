using System;

namespace DigitalAssetManagement.exception
{
    public class AssetNotMaintainException : Exception
    {
        public AssetNotMaintainException() : base("The asset has not been maintained for over 2 years.") { }

        public AssetNotMaintainException(string message) : base(message) { }

        public AssetNotMaintainException(string message, Exception inner) : base(message, inner) { }
    }
}
