namespace WebECommerce.Entity
{
    public class RelatorioPagamentosEntity
    {
        /*
         u.nome,pt.nome,pt.preco,pt.quantidade,pt.imagem,
         p.total,p.dataPagamento,tp.tipo
         FROM pagamentos p
         INNER JOIN produto pt on p.idProduto=pt.id
         INNER JOIN usuario u on p.idClinte=u.id
         INNER JOIN tipopagamento tp on p.idTipoPagamento=tp.id;
         */
        public int CodigoProduto { get; set; }
        public string Cliente { get; set; }
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public string Imagem { get; set; }
        public decimal Total { get; set; }
        public string DataPagamento { get; set; }
        public string TipoPagamento { get; set; }
    }
}
