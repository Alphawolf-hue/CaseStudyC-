using DigitalAssetManagement.dao;
using DigitalAssetManagement.exception;
using DigitalAssetManagement.model;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DigitalAssetManagement.MainModule
{
    public class AssetManagementMenu
    {
        private readonly IAssetManagementService _assetService;

        public AssetManagementMenu()
        {
            // Instantiate the service implementation
            _assetService = new AssetManagementServiceImpl();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Hey There! Welcome to Digital Asset Management System");
            while (true)
            {
                try
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Add Asset");
                    Console.WriteLine("2. Update Asset");
                    Console.WriteLine("3. Delete Asset");
                    Console.WriteLine("4. Allocate Asset");
                    Console.WriteLine("5. Deallocate Asset");
                    Console.WriteLine("6. Perform Maintenance");
                    Console.WriteLine("7. Reserve Asset");
                    Console.WriteLine("8. Withdraw Reservation");
                    Console.WriteLine("9. Display Assets table");
                    Console.WriteLine("10.Display all available assets");
                    Console.WriteLine("0. Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddAsset();
                            break;

                        case 2:
                            UpdateAsset();
                            break;

                        case 3:
                            DeleteAsset();
                            break;

                        case 4:
                            AllocateAsset();
                            break;

                        case 5:
                            DeallocateAsset();
                            break;

                        case 6:
                            PerformMaintenance();
                            break;

                        case 7:
                            ReserveAsset();
                            break;

                        case 8:
                            WithdrawReservation();
                            break;

                        case 9:

                            List<Asset> assetlist = _assetService.GetallAssets();
                            foreach (Asset asset in assetlist)
                            {
                                Console.WriteLine(asset.ToString());
                            }
                            break;

                        case 10:
                            List<Asset> availableAssets = _assetService.GetAvailableAssets();

                            if (availableAssets.Count == 0)
                            {
                                Console.WriteLine("No assets available for reservation.");
                                return;
                            }

                            foreach (Asset asset in availableAssets)
                            {
                                Console.WriteLine(asset.ToString());
                            }
                            break;

                        /*case 10:
                            List<AssetAllocation> allocationlist=_assetService.GetallAssetsAllocation();
                            foreach(AssetAllocation allocation in allocationlist)
                            {
                                Console.WriteLine(allocation.ToString());
                            }
                            break;*/

                        case 0:
                            // Exit
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please choose again.");
                            break;
                    }         
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
        private void AddAsset()
        {
            try
            {
                Console.WriteLine("Enter Asset Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Asset Type(Ex Electronics,Furniture,etc..):");
                string type = Console.ReadLine();
                Console.WriteLine("Enter Serial Number:");
                string serialNumber = Console.ReadLine();
                Console.WriteLine("Enter Purchase Date (yyyy-MM-dd):");
                DateTime purchaseDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Location:");
                string location = Console.ReadLine();
                Console.WriteLine("Enter Status in ('in use', 'decommissioned', 'under maintenance', 'available'):");
                string status = Console.ReadLine();
                Console.WriteLine("Enter Owner ID:");
                int ownerId = Convert.ToInt32(Console.ReadLine());

                Asset newAsset = new Asset
                {
                    Name = name,
                    Type = type,
                    SerialNumber = serialNumber,
                    PurchaseDate = purchaseDate,
                    Location = location,
                    Status = status,
                    OwnerId = ownerId
                };

                bool querystatus = _assetService.AddAsset(newAsset); // Return the number of rows affected
                Console.WriteLine(querystatus ? $"{querystatus} Asset Added Successfully" : "Failed to add asset");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
           
        }

        private void UpdateAsset()
        {
                // Update Asset Logic
                Console.WriteLine("Enter Asset ID to update:");
                int updateAssetId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Updated Asset Name:");
                string updatedName = Console.ReadLine();
                Console.WriteLine("Enter Updated Asset Type:");
                string updatedType = Console.ReadLine();
                Console.WriteLine("Enter Updated Serial Number:");
                string updatedSerialNumber = Console.ReadLine();
                Console.WriteLine("Enter Updated Purchase Date (yyyy-MM-dd):");
                DateTime updatedPurchaseDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Updated Location:");
                string updatedLocation = Console.ReadLine();
                Console.WriteLine("Enter Updated Status:");
                string updatedStatus = Console.ReadLine();
                Console.WriteLine("Enter Updated Owner ID:");
                int updatedOwnerId = Convert.ToInt32(Console.ReadLine());

                Asset updateAsset = new Asset
                {
                    AssetId = updateAssetId,
                    Name = updatedName,
                    Type = updatedType,
                    SerialNumber = updatedSerialNumber,
                    PurchaseDate = updatedPurchaseDate,
                    Location = updatedLocation,
                    Status = updatedStatus,
                    OwnerId = updatedOwnerId
                };
                bool rowsUpdated = _assetService.UpdateAsset(updateAsset); // Return number of rows affected
                Console.WriteLine(rowsUpdated ? $"{rowsUpdated} Asset updated successfully" : "Failed to update asset");
        }

        private void DeleteAsset()
        {
            try
            {
                // Delete Asset Logic
                Console.WriteLine("Enter Asset ID to delete:");
                int deleteAssetId = Convert.ToInt32(Console.ReadLine());
                bool rowsDeleted = _assetService.DeleteAsset(deleteAssetId); // Return number of rows affected
                Console.WriteLine(rowsDeleted ? $"{rowsDeleted} Asset deleted successfully" : "Failed to delete asset");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
        }

        private void AllocateAsset()
        {
            try
            {
                Console.WriteLine("Enter Asset ID to allocate:");
                int allocateAssetId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee ID for allocation:");
                int allocateEmployeeId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Allocation Date (yyyy-MM-dd):");
                string allocationDate = Console.ReadLine();
                Console.WriteLine("Enter Return date(yyyy-MM-dd):");
                string returnDate = Console.ReadLine();
                bool rowsAllocated = _assetService.AllocateAsset(allocateAssetId, allocateEmployeeId, allocationDate, returnDate); // Return number of rows affected
                Console.WriteLine(rowsAllocated ? $"{rowsAllocated} Asset allocated successfully" : "Failed to allocate asset");
            }
            catch (AssetAlreadyInUseException ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); 
            }   
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        private void DeallocateAsset()
        {
            try
            {
                Console.WriteLine("Enter Asset ID to deallocate:");
                int deallocateAssetId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee ID for deallocation:");
                int deallocateEmployeeId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Return Date (yyyy-MM-dd):");
                string returnDate = Console.ReadLine();

                bool rowsDeallocated = _assetService.DeallocateAsset(deallocateAssetId, deallocateEmployeeId, returnDate); // Return number of rows affected
                Console.WriteLine(rowsDeallocated ? $"{rowsDeallocated} Asset deallocated successfully" : "Failed to deallocate asset");
            }
            // Deallocate Asset Logic
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        private void PerformMaintenance()
        {
            try
            {
                Console.WriteLine("Enter Asset ID for maintenance:");
                int maintenanceAssetId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Maintenance Date (yyyy-MM-dd):");
                string maintenanceDate = Console.ReadLine();
                Console.WriteLine("Enter Maintenance Description:");
                string description = Console.ReadLine();
                Console.WriteLine("Enter Maintenance Cost:");
                double cost = Convert.ToDouble(Console.ReadLine());

                bool rowsMaintained = _assetService.PerformMaintenance(maintenanceAssetId, maintenanceDate, description, cost); // Return number of rows affected
                Console.WriteLine(rowsMaintained ? $"{rowsMaintained} Asset maintainance done successfully" : "Failed to perform maintenance");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            
        }

        private void ReserveAsset()
        {
            try
            {
                // Reserve Asset Logic
                Console.WriteLine("Enter Asset ID to reserve:");
                int reserveAssetId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee ID for reservation:");
                int reserveEmployeeId = Convert.ToInt32(Console.ReadLine());
                string reservationDate = DateTime.Now.ToString("yyyy-MM-dd");
                Console.WriteLine("Enter Reservation Start Date (yyyy-MM-dd):");
                string startDate = Console.ReadLine();
                Console.WriteLine("Enter Reservation End Date (yyyy-MM-dd):");
                string endDate = Console.ReadLine();
                Console.WriteLine("Enter Status in ('approved','canceled','pending'");
                string? Status = Console.ReadLine();
                bool rowsReserved = _assetService.ReserveAsset(reserveAssetId, reserveEmployeeId, reservationDate, startDate, endDate, Status); // Return number of rows affected
                Console.WriteLine(rowsReserved ? $"{rowsReserved} Asset reserved successfully" : "Failed to reserve asset");
            }
            catch (AssetAlreadyInUseException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
           
        }

        private void WithdrawReservation()
        {
            try
            {
                Console.WriteLine("Enter Reservation ID to withdraw:");
                int withdrawReservationId = Convert.ToInt32(Console.ReadLine());

                bool rowsWithdrawn = _assetService.WithdrawReservation(withdrawReservationId); // Return number of rows affected
                Console.WriteLine(rowsWithdrawn ? $"{rowsWithdrawn} Reservation withdrawn successfully" : "Failed to withdraw reservation");
            }
            // Withdraw Reservation Logic
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

    }
}    

