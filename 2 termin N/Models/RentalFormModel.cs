using System.ComponentModel.DataAnnotations;

namespace _2_termin_N.Models
{
    public class RentalFormModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "UserID must be 6 digits.")]
        public string UserId { get; set; }

        [Required]
        public string WarehouseId { get; set; }

        public static readonly string[] AvailableWarehouses = new string[] { "A5", "B5", "A10", "B10", "A20" };
    }
}
