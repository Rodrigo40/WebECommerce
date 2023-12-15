namespace WebECommerce.Entity
{
    public class ProdutosEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int Desconto { get; set; }
        public string Imagem { get; set; }
        public string DataCadastro { get; set; }

        public List<ProdutosEntity> ListarProdutos { get; set; }
    }
}
