using DigitalAssetManagement.dao;
using NUnit.Framework;
using DigitalAssetManagement.model;
using DigitalAssetManagement.MainModule;
using DigitalAssetManagement.exception;

namespace DigitalAssetMangement.Tests
{
    public class AssetTests
    {
        private IAssetManagementService assetManagementService;

        [SetUp]
        public void Setup()
        {
            assetManagementService = new AssetManagementServiceImpl(); 
        }

        [Test]
        [Ignore("Ignore")]
        public void Test_Asset_Creation()
        {
            Asset asset = new Asset
            {    
                Name = "Bottle",
                Type = "Utensils",
                SerialNumber = "BTE89890",
                PurchaseDate = DateTime.Now,
                Location = "Branch Office",
                Status = "available",
                OwnerId = 3
            };

            bool result = assetManagementService.AddAsset(asset);
            Assert.That(result, Is.True);
        }

        [Test]
        [Ignore("Ignore a test")]
        public void Test_Asset_Added_To_Maintenance_Successfully()
        {
            int assetId = 21;
            string maintenanceDate = DateTime.Now.ToString("2024-10-07");
            string description = "Replaced Cap";
            double cost = 110.00;

            bool result = assetManagementService.PerformMaintenance(assetId, maintenanceDate, description, cost);
            Assert.That(result, Is.True);
        }

        [Test]
        [Ignore("Ignore a test")]
        public void Reserved_Successfully()
        {
            int assetId = 17;
            int employeeId = 5;
            string reservationDate = DateTime.Now.ToString("yyyy-MM-dd");
            string startDate = DateTime.Now.AddDays(15).ToString("yyyy-MM-dd");
            string endDate = DateTime.Now.AddDays(15).AddDays(60).ToString("yyyy-MM-dd");
            string status = "pending";

            bool result = assetManagementService.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate, status);
            Assert.That(result, Is.True);
        }

        [Test]
        [Order(1)]
        public void Test_Exception_Thrown_When_AssetId_Not_Found()
        {
            int invalidAssetId = -1; 
            int employeeId = 5;
            string reservationDate = DateTime.Now.ToString("yyyy-MM-dd");
            string startDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string endDate = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd");
            string status = "approved";

            var ex = Assert.Throws<AssetNotFoundException>(() =>
                assetManagementService.ReserveAsset(invalidAssetId, employeeId, reservationDate, startDate, endDate, status));
            Assert.That(ex.Message, Is.EqualTo("Asset not found"));
        }

    }
}
