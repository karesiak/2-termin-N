using Microsoft.AspNetCore.Mvc;
using Magazyn.Models; // Upewnij się, że zaimportowałeś przestrzeń nazw swojego modelu

namespace Magazyn.Controllers
{
    public class NajemController : Controller
    {
        private static readonly List<WarehouseRental> rentals = new List<WarehouseRental>();

        // Wyświetla formularz
        [HttpGet]
        public IActionResult CreateForm()
        {
            var model = new Najem(); // Tworzy nową instancję modelu Najem
            return View(model); // Przekazuje model do widoku
        }

        // Przetwarza dane z formularza
        [HttpPost]
        public IActionResult CreateForm(Najem model) // Odbiera model Najem
        {
            if (ModelState.IsValid)
            {
                // Przekonwertuj model Najem na WarehouseRental
                var huj = new WarehouseRental
                {
                    // Załóżmy, że obie klasy mają te same nazwy i typy pól
                    Id = model.Id, // Musisz dostosować, jak mapujesz Id, jeśli są różne
                    DataStart = model.DataStart.ToString("yyyy-MM-dd"),
                    DataEnd = model.DataEnd.ToString("yyyy-MM-dd"),

                    TypMagazyn = model.TypMagazyn.ToString(),

                };

                // Dodaj przekonwertowany obiekt do listy
                rentals.Add(huj);

                // Przekieruj do akcji Sukces
                return RedirectToAction("Sukces");
            }

            // Jeśli model nie jest prawidłowy, wyświetl formularz ponownie
            return View(model);
        }

        public IActionResult Sukces()
        {
            return View();
        }

        public IActionResult RentalsList()
        {
            return View(rentals);
        }
    }
}
