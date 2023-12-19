using Microsoft.AspNetCore.Mvc;
using WebECommerce.Entity;
using WebECommerce.Models;

namespace WebECommerce.Controllers
{
    public class TipoUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Novo(int tipo, string descricao)
        {
            if (tipo != 0 && !string.IsNullOrEmpty(descricao))
            {
                var tpu = new TipoUsuarioModel();
                var tpe = new TipoUsuarioEntity();

                tpe.Tipo = Convert.ToInt32(tipo);
                tpe.Descricao = descricao;

                TempData["sms"] = tpu.Novo(tpe);

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Editar(int id)
        {
            if (id != 0)
            {
                var tpu = new TipoUsuarioModel();
                var tpe = new TipoUsuarioEntity();

                tpe.ListarTipoUsuarios = tpu.ListarTipoUsuarioById(id);

                return View(tpe);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Salvar(int id, int tipo, string descricao)
        {
            if (tipo != 0 && !string.IsNullOrEmpty(descricao))
            {
                var tpu = new TipoUsuarioModel();
                var tpe = new TipoUsuarioEntity();

                tpe.Id = Convert.ToInt32(id);
                tpe.Tipo = Convert.ToInt32(tipo);
                tpe.Descricao = descricao;

                TempData["sms"] = tpu.Editar(tpe);

                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Eliminar(int id)
        {
            if (id != 0)
            {
                var tpu = new TipoUsuarioModel();
                var tpe = new TipoUsuarioEntity();

                tpe.Id = id;

                TempData["sms"] = tpu.Eliminar(tpe);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
