namespace DigitalAssetManagement.model
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Status { get; set; }

        public Reservation() { }

        public Reservation(int reservationId, int assetId, int employeeId, DateTime reservationDate, DateTime startDate, DateTime endDate, string status)
        {
            ReservationId = reservationId;
            AssetId = assetId;
            EmployeeId = employeeId;
            ReservationDate = reservationDate;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        public override string ToString()
        {
            return $"ReservationID:{ReservationId}\n AssetID:{AssetId}\nEmployeeID:{EmployeeId}\nReservationDate:{ReservationDate}\nStartDate:{StartDate}\nEndDate:{EndDate}\nStatus:{Status}";
        }
    }
}
