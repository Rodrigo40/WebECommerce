using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebECommerce.Entity;
using WebECommerce.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebECommerce.Controllers
{
    public class UsuarioController : Controller
    {
        private string caminhoServidor;
        public UsuarioController(IWebHostEnvironment environment)
        {
            caminhoServidor = environment.WebRootPath;
        }

        public IActionResult Login(string email, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {

                    var usuario = new UsuarioEntity();
                    usuario.Email = email;
                    usuario.Password = password;

                    var login = new UsuarioModel();
                    var resposta = login.Login(usuario);

                    if (resposta.Count != 0)
                    {
                        // Carregando os dados do usuario atual
                        UsuarioEntity.GetInstancia().Id = Convert.ToInt32(resposta[0].Id);
                        UsuarioEntity.GetInstancia().IdTipo = Convert.ToInt32(resposta[0].IdTipo);
                        UsuarioEntity.GetInstancia().Nome = resposta[0].Nome;
                        UsuarioEntity.GetInstancia().Email = resposta[0].Email;

                        if (UsuarioEntity.GetInstancia().Nome != string.Empty)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }

                }
            }
            catch (Exception)
            {

            }
            return View();
        }
        public IActionResult Logout()
        {
            UsuarioEntity.GetInstancia().Id = 0;
            UsuarioEntity.GetInstancia().IdTipo = 0;
            UsuarioEntity.GetInstancia().Nome = string.Empty;
            UsuarioEntity.GetInstancia().Email = string.Empty;

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult SalvarEdicao()
        {
            return View();
        }

        public IActionResult Eliminar(int id)
        {
            return View();
        }
        public IActionResult Upload(IFormFile foto)
        {
            string caminhoParaSalverImagem = $"{caminhoServidor}\\images\\";
            string novoNomeImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;
            if (!Directory.Exists(caminhoParaSalverImagem))
            {
                Directory.CreateDirectory(caminhoParaSalverImagem);
            }
            using (var stream = System.IO.File.Create(caminhoParaSalverImagem + novoNomeImagem))
            {
                foto.CopyToAsync(stream);
            }
            return Redirect("/");
        }

    }
}
