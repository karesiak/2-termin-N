using formularz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


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
                // Serializacja obiektu Osoba do JSON i zapisanie w TempData przy użyciu System.Text.Json
                TempData["Osoba"] = JsonSerializer.Serialize(osoba);
                return RedirectToAction("ZapiszOsobe");
            }
            return View(osoba);
        }



        public ActionResult ZapiszOsobe()
        {
            Osoba osoba = null;

            if (TempData["Osoba"] is string osobaJson)
            {
                osoba = JsonSerializer.Deserialize<Osoba>(osobaJson);
            }

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
