﻿namespace WebECommerce.Entity
{
    public class PagamentosEntitty
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdCliente { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
    }
}
