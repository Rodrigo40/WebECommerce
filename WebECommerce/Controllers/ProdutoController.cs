using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebECommerce.Entity;
using WebECommerce.Models;

namespace WebECommerce.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]

    public class ProdutoController : Controller
    {
        private string caminhoServidor;

        public ProdutoController(IWebHostEnvironment environment)
        {
            caminhoServidor = environment.WebRootPath;
        }

        public IActionResult Novo(string produto, string preco, string quantidade, string desconto, IFormFile imagem)
        {
            if (!string.IsNullOrEmpty(produto) && !string.IsNullOrEmpty(preco) && !string.IsNullOrEmpty(quantidade) && !string.IsNullOrEmpty(desconto) && imagem != null)
            {
                var entidade = new ProdutosEntity();
                var prod = new ProdutosModel();
                var img = Upload(imagem);
                string resposta = string.Empty;

                entidade.Nome = produto;
                entidade.Preco = Convert.ToDecimal(preco);
                entidade.Quantidade = Convert.ToInt32(quantidade);
                entidade.Desconto = Convert.ToInt32(desconto);
                entidade.Desconto = Convert.ToInt32(desconto);
                entidade.Imagem = img;
                entidade.DataCadastro = DateTime.Now.ToShortDateString();
                resposta = prod.Novo(entidade);

                if (resposta == "Produto registrado com sucesso")
                {
                    TempData["sms"] = resposta;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["sms"] = resposta;
                }

            }
            return View();
        }
        public IActionResult Detalhes(int id, int quantidade, int tipo, string preco, string desconto)
        {
            //string pt = Request.QueryString[""].ToString();
            //string pt = Request["tipo"];
            if (!string.IsNullOrEmpty(WebECommerce.Entity.UsuarioEntity.GetInstancia().Nome))
            {
                if (id != 0)
                {
                    ViewBag.id = id;
                    if (quantidade != 0 && tipo != 0 && WebECommerce.Entity.UsuarioEntity.GetInstancia().IdTipo == 2)
                    {
                        var Cliente = new ClienteModel(id);
                        var IdCliente = Cliente.ListaClienteById[0].Id;
                        var pagamento = new PagamentosModel();

                        var pagamentoEntity = new PagamentosEntity();
                        pagamentoEntity.DataPagamento = DateTime.Now.ToShortDateString();
                        pagamentoEntity.IdTipoPagamento = tipo;
                        pagamentoEntity.IdProduto = id;
                        pagamentoEntity.IdCliente = WebECommerce.Entity.UsuarioEntity.GetInstancia().Id;

                        decimal precoProduto = Convert.ToDecimal(preco);
                        decimal descontoProduto = Convert.ToDecimal(desconto);

                        pagamentoEntity.Preco = precoProduto;
                        pagamentoEntity.Quantidade = quantidade;
                        pagamentoEntity.Total = precoProduto * quantidade - descontoProduto;

                        TempData["sms"] = pagamento.Novo(pagamentoEntity);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

            var tipoModel = new TipoPagamentoModel();
            return View(tipoModel);
        }
        public IActionResult Vendidos()
        {
            return View();
        }
        public IActionResult Lista()
        {
            var tipoPagamento = new TipoPagamentoModel();
            return View(tipoPagamento);
        }
        public IActionResult Editar(int id, string produto, string preco, string quantidade, string desconto, IFormFile imagem)
        {

            ViewBag.id = id;
            if (!string.IsNullOrEmpty(produto) && !string.IsNullOrEmpty(preco) && !string.IsNullOrEmpty(quantidade) && !string.IsNullOrEmpty(desconto) && id != 0)
            {
                Mensagens.GetInstancia().Mensagem = string.Empty;

                var produtos = new ProdutosModel();
                var entidate = new ProdutosEntity();


                entidate.Id = id;
                entidate.Nome = produto;
                entidate.Preco = Convert.ToDecimal(preco);
                entidate.Quantidade = Convert.ToInt32(quantidade);
                entidate.Desconto = Convert.ToInt32(desconto);

                if (imagem != null)
                {
                    var img = Upload(imagem);
                    entidate.Imagem = img;
                }
                else
                {
                    var prod = new ProdutosModel();
                    var prodId = prod.ListarProdutosById(id);
                    entidate.Imagem = prodId[0].Imagem;
                }
                TempData["sms"] = produtos.Editar(entidate);
                Mensagens.GetInstancia().Mensagem = TempData["sms"].ToString();
            }
            else
            {
                return View("Editar", produto);
            }
            return View("Lista", produto);
        }
        public IActionResult Eliminar(int id)
        {
            var produto = new ProdutosModel();
            var entidade = new ProdutosEntity();
            Mensagens.GetInstancia().Mensagem = string.Empty;
            if (id != 0)
            {

                entidade.Id = id;
                string resposta = produto.VerificarSeJaFoiVendido(id);
                if (resposta == "ok")
                {
                    TempData["sms"] = produto.Eliminar(entidade);
                    Mensagens.GetInstancia().Mensagem = resposta;
                }
                else
                {
                    TempData["sms"] = resposta;
                    Mensagens.GetInstancia().Mensagem = resposta;
                    return RedirectToAction("Lista", TempData["sms"]);
                }
            }
            else
            {
                Mensagens.GetInstancia().Mensagem = string.Empty;
                return RedirectToAction("Lista");
            }
            return RedirectToAction("Lista");
        }
        public string Upload(IFormFile foto)
        {
            string caminhoParaSalverImagem = $"{caminhoServidor}\\imagens\\";
            string novoNomeImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;
            if (!Directory.Exists(caminhoParaSalverImagem))
            {
                Directory.CreateDirectory(caminhoParaSalverImagem);
            }
            using (var stream = System.IO.File.Create(caminhoParaSalverImagem + novoNomeImagem))
            {
                foto.CopyToAsync(stream);
            }
            return novoNomeImagem;
        }
    }
}
