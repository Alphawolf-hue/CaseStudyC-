namespace DigitalAssetManagement.model

{
    public class AssetAllocation
    {
        public int AllocationId { get; set; }
        public int? AssetId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime AllocationDate { get; set; }
        
        public DateTime Returndate { get; set; }

        public AssetAllocation() { }

        public AssetAllocation(int allocationId, int assetId, int employeeId, DateTime allocationDate,DateTime returnDate)
        {
            AllocationId = allocationId;
            AssetId = assetId;
            EmployeeId = employeeId;
            AllocationDate = allocationDate;
            Returndate = returnDate;
        }
        /*public override string ToString()
        {
            return $"AllocationId:{AllocationId} AssetID:{AssetId} EmployeeID:{EmployeeId} DateAllocated:{AllocationDate} RetDate:{ReturnDate}";
        }*/
    }
}
