namespace Magazyn.Models
{
    public class WarehouseRental
    {
  
            public int Id { get; set; }
            public string DataStart { get; set; }
            public string DataEnd { get; set; }
            public string TypMagazyn { get; set; }
            // Możesz dodać więcej właściwości związanych z wynajmem
            public decimal Koszt { get; set; }
      
    }
}
