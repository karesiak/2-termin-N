﻿using Microsoft.AspNetCore.Mvc;
using Oceny.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oceny.Controllers
{
    public class OcenyController : Controller
    {
        private static readonly List<Ocena> _oceny = new List<Ocena>();
     
        public IActionResult AddOcena()
        {
            // Przygotowanie danych do wyboru dla użytkownika
            ViewBag.Przedmioty = new List<string> { "Matematyka", "Fizyka", "Informatyka", "Historia" };
            ViewBag.Oceny = new List<double> { 2, 3, 4, 5 };
            return View(new Ocena());
        }

        [HttpPost]
        public IActionResult AddOcena(Ocena ocena)
        {
            // Zawsze ustawiaj ViewBag, aby uniknąć ArgumentNullException
            ViewBag.Przedmioty = new List<string> { "Matematyka", "Fizyka", "Informatyka", "Historia" };
            ViewBag.Oceny = new List<double> { 2, 3, 4, 5 };

            if (ModelState.IsValid)
            {
                var istniejeOcena = _oceny.Any(o => o.NrAlbumu == ocena.NrAlbumu && o.Przedmiot == ocena.Przedmiot);
                if (istniejeOcena)
                {
                    ModelState.AddModelError(string.Empty, "Student ma już ocenę z tego przedmiotu.");
                    return View(ocena);
                }

                _oceny.Add(ocena);
                return RedirectToAction("Index");
            }

            return View(ocena);
        }


        public IActionResult Index()
        {
            // Grupowanie ocen po przedmiotach i przekazywanie do widoku
            var grupowaneOceny = _oceny.GroupBy(o => o.Przedmiot)
                .ToDictionary(g => g.Key, g => g.ToList());

            return View(grupowaneOceny);
        }

    }
}
