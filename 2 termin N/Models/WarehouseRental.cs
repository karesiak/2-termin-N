namespace _2_termin_N.Models
{
    public class WarehouseRental
    {
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
    }

}
