using formularz.Models;
using Microsoft.AspNetCore.Mvc;

namespace formularz.Controllers
{
    public class OsobaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Index(Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                // Zapisanie danych z formularza do TempData
                TempData["Osoba"] = osoba;
                return RedirectToAction("ZapiszOsobe");
            }
            return View(osoba);
        }


        public ActionResult ZapiszOsobe()
        {
            // Pobranie obiektu Osoba z TempData
            Osoba osoba = TempData["Osoba"] as Osoba;

            // Sprawdzamy, czy obiekt faktycznie istnieje
            if (osoba != null)
            {
                // Przekazanie obiektu Osoba do widoku
                return View(osoba);
            }
            else
            {
                // Przekierowanie z powrotem do formularza, jeśli nie ma danych
                return RedirectToAction("Index");
            }
        }


    }
}
