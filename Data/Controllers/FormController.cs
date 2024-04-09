using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Data.Controllers
{
    public class FormController : Controller
    {
        private static List<FormData> submittedData = new List<FormData>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            // Przygotowanie modelu z domyślną listą opcji (lub inicjalizacja na podstawie logiki aplikacji)
            var formData = new FormData()
            {
                // Zakładając, że FormData.Opcje jest już zdefiniowane static lub inaczej w modelu,
                // nie potrzebujemy dodatkowo inicjalizować listy opcji tutaj.
                // Przykład: formData.Opcje = PobierzOpcje(); jeśli lista opcji ma być dynamiczna.
            };

            return View(formData);
        }

        [HttpPost]
        public IActionResult Form(FormData formData)
        {
            if (ModelState.IsValid)
            {
                submittedData.Add(formData);
                return RedirectToAction("Results");
            }

            return View(formData);
        }

        public IActionResult Results()
        {
            return View(submittedData);
        }
    }
}
