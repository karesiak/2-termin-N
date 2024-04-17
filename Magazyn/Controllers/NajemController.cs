using Microsoft.AspNetCore.Mvc;
using Magazyn.Models; // Upewnij się, że zaimportowałeś przestrzeń nazw swojego modelu
using System;
using System.Collections.Generic;

namespace Magazyn.Controllers
{
    public class NajemController : Controller
    {
        private static readonly List<WarehouseRental> rentals = new List<WarehouseRental>();

        // Metoda do obliczania kosztu wynajmu
        private decimal CalculateRentCost(DateTime startDate, DateTime endDate, string warehouseType)
        {
            int totalDays = (endDate - startDate).Days + 1; // Uwzględnienie także dnia rozpoczęcia
            decimal pricePerDay;

            switch (warehouseType)
            {
                case "A5":
                case "B5":
                    pricePerDay = 2m;
                    break;
                case "A10":
                case "B10":
                    pricePerDay = 3m;
                    break;
                case "A20":
                    pricePerDay = 5m;
                    break;
                default:
                    throw new ArgumentException("Nieznany typ magazynu");
            }

            return totalDays * pricePerDay;
        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            var model = new Najem();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateForm(Najem model)
        {
            if (ModelState.IsValid)
            {
                if (model.DataStart >= model.DataEnd)
                {
                    ModelState.AddModelError("", "Data rozpoczęcia musi być wcześniejsza niż data zakończenia.");
                    return View(model);
                }
                // Użyj ToString() do konwersji TypMagazyn z enum na string
                string warehouseType = model.TypMagazyn.ToString();
                var rentalCost = CalculateRentCost(model.DataStart, model.DataEnd, warehouseType); // Teraz przekazujemy string

                var rental = new WarehouseRental
                {
                    Id = model.Id,
                    DataStart = model.DataStart.ToString("yyyy-MM-dd"), // Zakładamy, że format daty jest odpowiedni
                    DataEnd = model.DataEnd.ToString("yyyy-MM-dd"),
                    TypMagazyn = warehouseType, // Tutaj również przekazujemy wartość jako string
                    Koszt = rentalCost // Przypisanie obliczonego kosztu
                };

                rentals.Add(rental);

                return RedirectToAction("Sukces");
            }

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
