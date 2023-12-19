using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebECommerce.Entity;
using WebECommerce.Models;

namespace WebECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string caminhoServidor;
        private string caminhoCompleto;
        public List<string> lista;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            caminhoServidor = environment.WebRootPath;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sobre()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
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