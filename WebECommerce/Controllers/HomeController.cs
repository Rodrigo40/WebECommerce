using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebECommerce.Entity;
using WebECommerce.Models;

namespace WebECommerce.Controllers
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
            try
            {
                Mensagens.GetInstancia().Mensagem = string.Empty;
                var produtos = new ProdutosModel();
                var lista = produtos.ListarProdutos();
                if (lista.Count != 0)
                {
                    return View(produtos);
                }

            }
            catch (Exception)
            {
            }
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