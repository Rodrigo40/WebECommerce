﻿using MySql.Data.MySqlClient;
using System.Data;
using WebECommerce.Entity;

namespace WebECommerce.Models
{
    public class ProdutosModel
    {
        #region Padrão Singleton
        private static ProdutosModel Instancia = null;
        public ProdutosModel() { }
        public static ProdutosModel GetInstacia()
        {
            if ( Instancia == null )
            {
                Instancia = new ProdutosModel();
            }
            return Instancia;
        }
        #endregion

        public List<ProdutosEntity> ListarProdutos()
        {
            List<ProdutosEntity> ListaProdutos = new List<ProdutosEntity>();
            ConexaoModel conex = new ConexaoModel();
            //Instanciando a class de conexão do MySql
            MySqlConnection con = new MySqlConnection();
            //Instanciando a class de comando do MySql
            MySqlCommand cmd = new MySqlCommand();
            try
            {

                //Definindo a conexão string
                con.ConnectionString = conex.GetConnection();
                //Abrindo a conexão com o servidor
                con.Open();

                //Conectando o comando com a conexão
                cmd.Connection = con;
                //Definindo o tipo de comando a usar
                cmd.CommandType = CommandType.StoredProcedure;
                //Definindo o comando de consulta sql
                cmd.CommandText = "listarProduto"; // Consulta Sql
                //cmd.CommandText = "Login";
                //cmd.Parameters.AddWithValue("email",user.Email);
                //cmd.Parameters.AddWithValue("password",user.Password);
                //Definindo o objeto MySqlDataReader para executar o comando
                //E Ler a resposta ou seja: trará a resposta do comando
                MySqlDataReader adapter = cmd.ExecuteReader();

                //Verifinado se exitem linhas na resposta do comando
                if (adapter.HasRows)
                {
                    while (adapter.Read())
                    {
                        ProdutosEntity entity = new ProdutosEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Nome = adapter["nome"].ToString();
                        entity.Preco = Convert.ToDecimal(adapter["preco"].ToString());
                        entity.Quantidade = Convert.ToInt32(adapter["quantidade"].ToString());
                        entity.Desconto = Convert.ToInt32(adapter["desconto"].ToString());
                        entity.Imagem = adapter["iamgem"].ToString();
                        ListaProdutos.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaProdutos;
        }
        public List<ProdutosEntity> ListarProdutosById(ProdutosEntity produto)
        {
            List<ProdutosEntity> ListaProdutos = new List<ProdutosEntity>();
            ConexaoModel conex = new ConexaoModel();
            //Instanciando a class de conexão do MySql
            MySqlConnection con = new MySqlConnection();
            //Instanciando a class de comando do MySql
            MySqlCommand cmd = new MySqlCommand();
            try
            {

                //Definindo a conexão string
                con.ConnectionString = conex.GetConnection();
                //Abrindo a conexão com o servidor
                con.Open();

                //Conectando o comando com a conexão
                cmd.Connection = con;
                //Definindo o tipo de comando a usar
                cmd.CommandType = CommandType.StoredProcedure;
                //Definindo o comando de consulta sql
                cmd.CommandText = "listarProdutoById"; // Consulta Sql
                cmd.Parameters.AddWithValue("id",produto.Id);
                //cmd.CommandText = "Login";
                //cmd.Parameters.AddWithValue("email",user.Email);
                //cmd.Parameters.AddWithValue("password",user.Password);
                //Definindo o objeto MySqlDataReader para executar o comando
                //E Ler a resposta ou seja: trará a resposta do comando
                MySqlDataReader adapter = cmd.ExecuteReader();

                //Verifinado se exitem linhas na resposta do comando
                if (adapter.HasRows)
                {
                    while (adapter.Read())
                    {
                        ProdutosEntity entity = new ProdutosEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Nome = adapter["nome"].ToString();
                        entity.Preco = Convert.ToDecimal(adapter["preco"].ToString());
                        entity.Quantidade = Convert.ToInt32(adapter["quantidade"].ToString());
                        entity.Desconto = Convert.ToInt32(adapter["desconto"].ToString());
                        entity.Imagem = adapter["iamgem"].ToString();
                        ListaProdutos.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaProdutos;
        }
        public string Novo(ProdutosEntity produto)
        {
            // Instanciando a class de conexão string
            ConexaoModel conex = new ConexaoModel();
            string resposta = string.Empty;
            try
            {
                //Instanciando a class de conexão do MySql
                MySqlConnection con = new MySqlConnection();
                //Definindo a conexão string
                con.ConnectionString = conex.GetConnection();
                //Abrindo a conexão com o servidor
                con.Open();

                //Instanciando a class de comando do MySql
                MySqlCommand cmd = new MySqlCommand();
                //Conectando o comando com a conexão
                cmd.Connection = con;
                //Definindo o tipo de comando a usar
                cmd.CommandType = CommandType.StoredProcedure;
                //Definindo o comando de consulta sql
                cmd.CommandText = "novoProduto"; // Consulta Sql

                cmd.Parameters.AddWithValue("nome", produto.Nome);
                cmd.Parameters.AddWithValue("preco", produto.Preco);
                cmd.Parameters.AddWithValue("quantidade", produto.Quantidade);
                cmd.Parameters.AddWithValue("desconto", produto.Desconto);
                cmd.Parameters.AddWithValue("imagem", produto.Imagem);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Produto registrado com sucesso";
                }
                else
                    resposta = "Erro: Produto não registrado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Editar(ProdutosEntity produto)
        {
            // Instanciando a class de conexão string
            ConexaoModel conex = new ConexaoModel();
            string resposta = string.Empty;
            try
            {
                //Instanciando a class de conexão do MySql
                MySqlConnection con = new MySqlConnection();
                //Definindo a conexão string
                con.ConnectionString = conex.GetConnection();
                //Abrindo a conexão com o servidor
                con.Open();

                //Instanciando a class de comando do MySql
                MySqlCommand cmd = new MySqlCommand();
                //Conectando o comando com a conexão
                cmd.Connection = con;
                //Definindo o tipo de comando a usar
                cmd.CommandType = CommandType.StoredProcedure;
                //Definindo o comando de consulta sql
                cmd.CommandText = "editarProduto"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", produto.Id);
                cmd.Parameters.AddWithValue("nome", produto.Nome);
                cmd.Parameters.AddWithValue("preco", produto.Preco);
                cmd.Parameters.AddWithValue("quantidade", produto.Quantidade);
                cmd.Parameters.AddWithValue("desconto", produto.Desconto);
                cmd.Parameters.AddWithValue("imagem", produto.Imagem);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Produto atualizado com sucesso";
                }
                else
                    resposta = "Erro: Produto não atualizado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Eliminar(ProdutosEntity produto)
        {
            // Instanciando a class de conexão string
            ConexaoModel conex = new ConexaoModel();
            string resposta = string.Empty;
            try
            {
                //Instanciando a class de conexão do MySql
                MySqlConnection con = new MySqlConnection();
                //Definindo a conexão string
                con.ConnectionString = conex.GetConnection();
                //Abrindo a conexão com o servidor
                con.Open();

                //Instanciando a class de comando do MySql
                MySqlCommand cmd = new MySqlCommand();
                //Conectando o comando com a conexão
                cmd.Connection = con;
                //Definindo o tipo de comando a usar
                cmd.CommandType = CommandType.StoredProcedure;
                //Definindo o comando de consulta sql
                cmd.CommandText = "eliminarProduto"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", produto.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Produto eliminado com sucesso";
                }
                else
                    resposta = "Erro: Produto não eliminado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
    }
}
