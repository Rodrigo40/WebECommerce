using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
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

        public async Task<IActionResult> Login(string email, string password)
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
                            var clain = new List<Claim>();

                            clain.Add(new Claim(ClaimTypes.Name, resposta[0].Nome));
                            clain.Add(new Claim(ClaimTypes.Sid, resposta[0].Id.ToString()));

                            var userIdentity = new ClaimsIdentity(clain, "Acesso");
                            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                            await HttpContext.SignInAsync("CookieAuthentication",
                            principal, new AuthenticationProperties());


                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewData["sms"] = "Usuário senha incorrectos!";
                    }

                }
            }
            catch (Exception)
            {

            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            UsuarioEntity.GetInstancia().Id = 0;
            UsuarioEntity.GetInstancia().IdTipo = 0;
            UsuarioEntity.GetInstancia().Nome = string.Empty;
            UsuarioEntity.GetInstancia().Email = string.Empty;

            await HttpContext.SignOutAsync("CookieAuthentication");
            HttpContext.User = null;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Novo(string nome, string email, string password, string idTipo)
        {
            try
            {
                if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(idTipo))
                {
                    var entidadeU = new UsuarioEntity();
                    var Usuario = new UsuarioModel();

                    entidadeU.Nome = nome;
                    entidadeU.Email = email;
                    entidadeU.Password = password;
                    entidadeU.IdTipo = Convert.ToInt32(idTipo);

                    TempData["sms"] = Usuario.Novo(entidadeU);

                    if (TempData["sms"].ToString() == "Usuario registrado com sucesso")
                    {
                        return View("Login");
                    }
                    else
                    {
                        TempData["sms"] = "Houve um erro verifique os dados!";
                        return View();
                    }
                }
            }
            catch (Exception)
            {
            }
            return View();
        }
        public IActionResult Editar(int id)
        {
            var user = new UsuarioModel();
            var entity = new UsuarioEntity();
            entity.Id = id;
            entity.ListaUsuario = user.ListarUsuariosById(entity);

            return View(entity);
        }       
        public IActionResult ListarUsuario()
        {
            var usuario = new UsuarioModel();
            return View(usuario);
        }
        public IActionResult SalvarEdicaoUsuario(string id, string nome, string email, string password)
        {
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                int ID = Convert.ToInt32(id);

                var enty = new UsuarioEntity();
                var usuario = new UsuarioModel();

                enty.Id = ID;


                enty.Nome = nome;
                enty.Email = email;
                enty.Password = password;
                TempData["sms"] = usuario.Editar(enty);

                return RedirectToAction("ListarUsuario");
            }
            return RedirectToAction("Editar");
        }
        public IActionResult EditarUsuario(int id)
        {
            //ViewBag.id = id;
            //var Tipo = new UsuarioModel();
            //var TipoEnty = new UsuarioEntity();

            //TipoEnty.ListaUsuario = Tipo.ListarUsuariosById(id);
            // return View(Tipo);
            var user = new UsuarioModel();
            var Enty = new UsuarioEntity();
            Enty.Id = id;
            Enty.ListaUsuario = user.ListarUsuariosById(Enty);
            return View(Enty);
        }
        public IActionResult SalvarEdicao()
        {
            return View();
        }
        public IActionResult Eliminar(int id)
        {
            return View();
        }
        public IActionResult EliminarUsuario(int id)
        {
            var user = new UsuarioModel();
            var Enty = new UsuarioEntity();

            Enty.Id = id;
            TempData["sms"] = user.Eliminar(Enty);
            return View("ListarUsuario", user);

        }

        public IActionResult Upload(IFormFile foto)
        {
            string caminhoParaSalverImagem = $"{caminhoServidor}\\images\\";
            string novoNomeImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;
            if (!Directory.Exists(caminhoParaSalverImagem))
            {
                Directory.CreateDirectory(caminhoParaSalverImagem);
            }

            string CaminhoCompleto = $"{caminhoParaSalverImagem}{novoNomeImagem}";

            FileTools.GetInstancia().SalvarImagem(CaminhoCompleto, foto);

            return Redirect("/");
        }
        public IActionResult Perfil(int id)
        {
            var user = new UsuarioModel();
            var entity = new UsuarioEntity();
            entity.Id = id;

            entity.ListaUsuario = user.ListarUsuariosById(entity);

            return View(entity);
        }
        public IActionResult Salvar(string id, string nome, string email, string password)
        {
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var user = new UsuarioModel();

                var entity = new UsuarioEntity();
                entity.Id = Convert.ToInt32(id);
                entity.Nome = nome;
                entity.Email = email;
                entity.Password = password;

                TempData["sms"] = user.Editar(entity);
                entity.ListaUsuario = user.ListarUsuariosById(entity);
                return View("Perfil", entity);
            }
            else
            {
                return RedirectToAction("Editar");
            }
        }
        public IActionResult HistoricoCompra()
        {
            var produtos = new ProdutosModel();
            var entity = new RelatorioPagamentosEntity();
            int idCliente = UsuarioEntity.GetInstancia().Id;
            entity.ListarPagamentos = produtos.ListarProdutosPagosClienteById(idCliente);
            return View(entity);
        }
    }
}
