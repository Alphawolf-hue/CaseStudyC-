using System;

namespace DigitalAssetManagement.exception
{
    public class AssetAlreadyInUseException : Exception
    {
        public AssetAlreadyInUseException()
        {
        }

        public AssetAlreadyInUseException(string? message) : base(message)
        {
        }

        public AssetAlreadyInUseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        
    }
}