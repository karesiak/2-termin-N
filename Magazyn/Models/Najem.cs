using System.ComponentModel.DataAnnotations;

namespace Magazyn.Models
{
    public class Najem
    {
        [Required]
        [RegularExpression(@"^\d{6}$",ErrorMessage ="ma byc 6 znaków")]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataEnd { get; set; }
        [Required]
        public Typ TypMagazyn { get; set; }
    }
    public enum Typ
    {
        A5, B5, A10, B10, A20
    }
}
