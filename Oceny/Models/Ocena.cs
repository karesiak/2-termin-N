using System.ComponentModel.DataAnnotations;

namespace Oceny.Models
{
    public class Ocena
    {   

        public int Id { get; set; }
        public string Przedmiot { get; set; }

        public int NrAlbumu { get; set; }
    
        public string ImieNazwiskoStudenta { get; set; }

        public double WartoscOceny { get; set; }
        public DateTime DataWpisania { get; set; } = DateTime.Now;
    }

}
