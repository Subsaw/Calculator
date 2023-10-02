using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Adda";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry" : "Dobry wieczór";


            Dane[] osoby =
            {
                new Dane {Name = "Anna", Surname="Kowalska"},
                new Dane {Name = "Jan", Surname="Zbedny"},
                new Dane {Name = "Mateusz", Surname="Uwalowisz"},
            };

            return View(osoby);


        }

        public IActionResult Urodziny( Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} lat";
            return View();
        }

        public IActionResult Kalkulator(Kalkulator kalkulator)
        {
            ViewBag.wynik = 0;
            if(kalkulator.znak == "-")
            {
                ViewBag.wynik = kalkulator.cyfra1 - kalkulator.cyfra2;
            }else if(kalkulator.znak == "+")
            {
                ViewBag.wynik = kalkulator.cyfra1 + kalkulator.cyfra2;
            }
            else if (kalkulator.znak == "/")
            {
                ViewBag.wynik = kalkulator.cyfra1 / kalkulator.cyfra2;
            }
            else if (kalkulator.znak == "*")
            {
                ViewBag.wynik = kalkulator.cyfra1 * kalkulator.cyfra2;
            }

            ViewBag.wynik = $"{kalkulator.cyfra1} {kalkulator.znak} {kalkulator.cyfra2} = {ViewBag.wynik}"; 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}