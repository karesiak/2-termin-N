using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace Oceny.Models
{
    public class Ocena
    {   

        public int Id { get; set; }
        public string Przedmiot { get; set; }

        [Required(ErrorMessage = "Numer albumu ucznia jest wymagany")]
        public int? NrAlbumu { get; set; }

        [Required(ErrorMessage ="Imie jest wymagane")]
        public string ImieNazwiskoStudenta { get; set; }

        public double WartoscOceny { get; set; }
        public DateTime DataWpisania { get; set; } = DateTime.Now;
    }

}
