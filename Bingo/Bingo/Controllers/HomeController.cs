using Bingo.Models;
using Bingo.Rules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace Bingo.Controllers
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
            var rule = new CartonRules();
            var carton = rule.Crear();
            return View(carton);
        }

        public IActionResult Jugar()
        {
            var rule = new CartonRules();
            var carton = rule.Crear();
            ViewBag.carton = carton;
            return View("Index",carton);
        }

        public  IActionResult Sortear()
        {
            Random ran = new Random();
            var numero = ran.Next(1,91);
            ViewBag.numero = numero;
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}