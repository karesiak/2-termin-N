using _2_termin_N.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _2_termin_N.Controllers
{
    public class RentalController : Controller
    {
        private static readonly List<WarehouseRental> rentals = new List<WarehouseRental>();

        public ActionResult Index()
        {
            return View();
        }

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
                    ModelState.AddModelError("EndDate", "End date must be later than start date.");
                    return View(model);
                }

                var totalDays = (model.EndDate - model.StartDate).Days;
                decimal pricePerDay = model.WarehouseId switch
                {
                    "A5" or "B5" => 2m,
                    "A10" or "B10" => 3m,
                    "A20" => 5m,
                    _ => throw new ArgumentException("Invalid warehouse ID")
                };

                var rental = new WarehouseRental
                {
                    UserId = model.UserId,
                    WarehouseId = model.WarehouseId,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    TotalCost = totalDays * pricePerDay
                };

                rentals.Add(rental);

                return RedirectToAction("Success");
            }

            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult RentalsList()
        {
            return View(rentals);
        }
    }
}
