using Microsoft.AspNetCore.Mvc;
using WebECommerce.Entity;
using WebECommerce.Models;

namespace WebECommerce.Controllers
{
    public class TipoPagamentoController : Controller
    {
        public IActionResult Index()
        {
            var Tipo = new TipoPagamentoModel();
            return View(Tipo);
        }
        public IActionResult Novo(string tipo, string descricao)
        {
            if (!string.IsNullOrEmpty(tipo) && !string.IsNullOrEmpty(descricao))
            {
                var tp = new TipoPagamentoModel();
                var enty = new TipoPagamentoEntity();

                enty.Tipo = tipo;
                enty.Descricao = descricao;

                TempData["sms"] = tp.Novo(enty);

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Salvar(string id, string tipo, string descricao)
        {
            if (!string.IsNullOrEmpty(tipo) && !string.IsNullOrEmpty(descricao) && !string.IsNullOrEmpty(id))
            {
                int ID = Convert.ToInt32(id);
                var tp = new TipoPagamentoModel();
                var enty = new TipoPagamentoEntity();

                enty.Id = ID;
                enty.Tipo = tipo;
                enty.Descricao = descricao;

                TempData["sms"] = tp.Editar(enty);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Editar");
        }
        public IActionResult Editar(int id)
        {
            var Tipo = new TipoPagamentoModel();
            var TipoEnty = new TipoPagamentoEntity();

            TipoEnty.ListaTipo = Tipo.ListarTipoPagamentoById(id);
            return View(TipoEnty);
        }
        public IActionResult Eliminar(int id)
        {
            var tipo = new TipoPagamentoModel();
            var tipoEnty = new TipoPagamentoEntity();

            tipoEnty.Id = id;

            //TempData["sms"] = tipo.Eliminar(tipoEnty);
            return View("Index");
        }
    }
}
