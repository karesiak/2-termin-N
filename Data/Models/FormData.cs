using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class FormData
    {
        [Required(ErrorMessage = "t")]
        [MinLength(3, ErrorMessage = "Pole powinno zawierać minimun 3 znaki")]
        public string Data1 { get; set; }

        [Required(ErrorMessage = "t")]
        [MinLength(3, ErrorMessage = "Pole powinno zawierać minimun 3 znaki")]
        public string Data2 { get; set; }
    }
}
