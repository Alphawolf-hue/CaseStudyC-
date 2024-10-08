namespace DigitalAssetManagement.model
{
    public class MaintenanceRecord
    {
        public int MaintenanceId { get; set; }
        public int AssetId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }

        public MaintenanceRecord() { }

        public MaintenanceRecord(int maintenanceId, int assetId, DateTime maintenanceDate, string description, decimal cost)
        {
            MaintenanceId = maintenanceId;
            AssetId = assetId;
            MaintenanceDate = maintenanceDate;
            Description = description;
            Cost = cost;
        }
    }
}
