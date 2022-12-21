using Microsoft.AspNetCore.Mvc;
using P1_ASP.Models;
using P1_ASP.Services;
using System.Diagnostics;

namespace P1_ASP.Controllers
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
            ViewBag.Vname = "Author: Marta Calvet Guasch";
            ViewBag.V2 = "Programadora ASP.net";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Proyectos()
        {
            ViewBag.Vproject = new RepositoryOfFormaciones().GetProjects();
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult FormacionAcademica()
        {
            return View();
        }

        public IActionResult Experiencia()
        {
            return View();
        }

        public IActionResult SobreMi()
        {
            return View();
        }

        public IActionResult ConocimientosTecnicos()
        {
            return View();
        }

		public IActionResult Resumen()
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