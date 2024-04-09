using _2_termin_N.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _2_termin_N.Controllers
{
    public class RentalController : Controller
    {
        private static readonly List<WarehouseRental> rentals = new List<WarehouseRental>();       

        public ActionResult Rent()
        {
            ViewBag.AvailableWarehouses = RentalFormModel.AvailableWarehouses;
            return View(new RentalFormModel());
        }

        [HttpPost]
        public ActionResult Rent(RentalFormModel model)
        {
            ViewBag.AvailableWarehouses = RentalFormModel.AvailableWarehouses;

            if (ModelState.IsValid)
            {
                if (model.StartDate > model.EndDate)
                {
                    ModelState.AddModelError("EndDate", "Data zakończenia musi być późniejsza niż data rozpoczęcia.");
                    return View(model);
                }

                var isNotAvailable = rentals.Any(rental =>
                    rental.WarehouseId == model.WarehouseId &&
                    !(model.EndDate <= rental.StartDate || model.StartDate >= rental.EndDate));

                if (isNotAvailable)
                {
                    ModelState.AddModelError("WarehouseId", "Wybrany magazyn nie jest dostępny w wybranym okresie.");
                    return View(model);
                }

                decimal pricePerDay = 0m;
                switch (model.WarehouseId)
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
                }

                var totalDays = (model.EndDate - model.StartDate).Days + 1; 
                var totalCost = totalDays * pricePerDay;

                var newRental = new WarehouseRental
                {
                    WarehouseId = model.WarehouseId,
                    UserId = model.UserId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    TotalCost = totalCost
                };

                rentals.Add(newRental);

                return RedirectToAction("Confirmation", new { id = newRental.WarehouseId });
            }

            return View(model);
        }


        public ActionResult Confirmation()
        {
            return View();
        }

        public ActionResult RentalsList()
        {
            return View(rentals);
        }
    }
}
