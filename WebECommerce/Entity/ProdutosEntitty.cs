namespace WebECommerce.Entity
{
    public class ProdutosEntitty
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int Desconto { get; set; }
        public string Imagem { get; set; }
    }
}
