using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebECommerce.Entity;
using WebECommerce.Models;

namespace WebECommerce.Controllers
{
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
        public IActionResult Detalhes(int id, int quantidade, int tipo, string preco,string desconto)
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
                        pagamentoEntity.Total = precoProduto * quantidade- descontoProduto;
                        
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
    }
}
