namespace DigitalAssetManagement.model
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }
        public int OwnerId { get; set; }

        public Asset() { }

        public Asset(int assetId, string name, string type, string serialNumber, DateTime purchaseDate, string location, string status, int ownerId)
        {
            AssetId = assetId;
            Name = name;
            Type = type;
            SerialNumber = serialNumber;
            PurchaseDate = purchaseDate;
            Location = location;
            Status = status;
            OwnerId = ownerId;
        }

        public override string ToString()
        {
            return $"ID:{AssetId}\t name:{Name}\t Type:{Type}\t SerialNumber:{SerialNumber}\t pd:{PurchaseDate}\tloc:{Location}\t status:{Status}\t owner:{OwnerId}";
        }
        
    }
}
