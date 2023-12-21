using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
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
                    if (quantidade != 0 && tipo != 0)
                    {
                        var Cliente = new ClienteModel(UsuarioEntity.GetInstancia().Id);
                        var IdCliente = Cliente.ListaClienteById[0].Id;
                        var pagamento = new PagamentosModel();
                        var produto = new ProdutosModel();

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
                        TempData["sms"] = produto.AtualizarStockProduto(id, quantidade);

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
        public IActionResult Editar(int id)
        {
            var produtos = new ProdutosModel();
            ViewBag.id = id;
            return View("Editar", produtos);
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
        public IActionResult Salvar(string id, string produto, string preco, string quantidade, string desconto, IFormFile imagem)
        {
            var produtos = new ProdutosModel();
            var entidate = new ProdutosEntity();
            int idProduto = Convert.ToInt32(id);
            if (!string.IsNullOrEmpty(produto) && !string.IsNullOrEmpty(preco) && !string.IsNullOrEmpty(quantidade) && !string.IsNullOrEmpty(desconto) && idProduto != 0)
            {
                Mensagens.GetInstancia().Mensagem = string.Empty;

                entidate.Id = idProduto;
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
                    var prodId = prod.ListarProdutosById(idProduto);
                    entidate.Imagem = prodId[0].Imagem;
                }
                TempData["sms"] = produtos.Editar(entidate);
                Mensagens.GetInstancia().Mensagem = TempData["sms"].ToString();
            }
            else
            {
                return View("Editar", produtos);
            }
            return RedirectToAction("Lista");
        }
        public IActionResult Pesquisa(string pesquisa)
        {
            var enty = new ProdutosEntity();
            var produto = new ProdutosModel();
            if (!string.IsNullOrEmpty(pesquisa))
            {
                enty.Nome = pesquisa;
                enty.ListarProdutos = produto.PesquisarProdutos(enty);

                return View("Pesquisa", enty);

            }
            return View("Pesquisa", enty);
        }
    }
}
