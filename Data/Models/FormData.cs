using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class FormData
    {
        [Required(ErrorMessage = "Uzupełnij Pole")]
        [MinLength(3, ErrorMessage = "Pole powinno zawierać minimun 3 znaki")]
        public string Data1 { get; set; }

        [Required(ErrorMessage = "Uzupełnij Pole")]
        [MinLength(3, ErrorMessage = "Pole powinno zawierać minimun 3 znaki")]
        public string Data2 { get; set; }

        [Required(ErrorMessage = "Wybór opcji jest wymagany.")]
        public string WybranaOpcja { get; set; }

        // Lista opcji dla elementu select
        public List<string> Opcje = new List<string> { "Opcja 1", "Opcja 2", "Opcja 3" };
    }
}
