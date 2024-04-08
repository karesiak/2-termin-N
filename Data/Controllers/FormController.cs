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
            return View();
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
