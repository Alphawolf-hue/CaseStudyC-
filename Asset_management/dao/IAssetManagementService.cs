using DigitalAssetManagement.model;

namespace DigitalAssetManagement.dao
{
    public interface IAssetManagementService
    {
        bool AddAsset(Asset asset);
        bool UpdateAsset(Asset asset);
        bool DeleteAsset(int assetId);
        bool AllocateAsset(int assetId, int employeeId, string allocationDate, string returnDate);
        bool DeallocateAsset(int assetId, int employeeId, string returnDate);
        bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost);
        bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate, string? status);
        bool WithdrawReservation(int reservationId);

         List<Asset> GetallAssets();
        /* List<AssetAllocation> GetallAssetsAllocation();*/
        List<Asset> GetAvailableAssets();

        
    }
}
