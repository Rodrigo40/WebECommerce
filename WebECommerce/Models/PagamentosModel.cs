using MySql.Data.MySqlClient;
using System.Data;
using WebECommerce.Entity;

namespace WebECommerce.Models
{
    public class PagamentosModel
    {
        public List<PagamentosEntity> ListarPagamento()
        {
            List<PagamentosEntity> ListaPagamento = new List<PagamentosEntity>();
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
                cmd.CommandText = "listarPagamento"; // Consulta Sql
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
                        PagamentosEntity entity = new PagamentosEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.IdProduto = Convert.ToInt32(adapter["idProduto"].ToString());
                        entity.IdCliente = Convert.ToInt32(adapter["idClinte"].ToString());
                        entity.Preco = Convert.ToDecimal(adapter["preco"].ToString());
                        entity.Quantidade = Convert.ToInt32(adapter["quantidade"].ToString());
                        entity.IdTipoPagamento = Convert.ToInt32(adapter["idTipoPagamento"].ToString());
                        entity.Total = Convert.ToDecimal(adapter["total"].ToString());
                        entity.DataPagamento = adapter["dataPagamento"].ToString();
                        ListaPagamento.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaPagamento;
        }
        public static List<RelatorioPagamentosEntity> ListarRelatorioPagamentos()
        {
            List<RelatorioPagamentosEntity> ListaPagamento = new List<RelatorioPagamentosEntity>();
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
                cmd.CommandText = "ListarRelatorioPagamento"; // Consulta Sql
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
                        RelatorioPagamentosEntity entity = new RelatorioPagamentosEntity();
                        entity.Cliente = adapter["cliente"].ToString();
                        entity.Produto = adapter["produto"].ToString();
                        entity.Preco = Convert.ToDecimal(adapter["preco"].ToString());
                        entity.Quantidade = Convert.ToInt32(adapter["quantidade"].ToString());
                        entity.Imagem = adapter["imagem"].ToString();
                        entity.Total = Convert.ToDecimal(adapter["total"].ToString());
                        entity.DataPagamento = adapter["dataPagamento"].ToString();
                        entity.TipoPagamento = adapter["tipoPagamento"].ToString();
                        entity.CodigoProduto = Convert.ToInt32(adapter["id"].ToString());
                        ListaPagamento.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaPagamento;
        }
        public List<RelatorioPagamentosEntity> ListarRelatorioPagamentosByData(RelatorioPagamentosEntity relatorio)
        {
            List<RelatorioPagamentosEntity> ListaPagamento = new List<RelatorioPagamentosEntity>();
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
                cmd.CommandText = "ListarRelatorioPagamentoByData"; // Consulta Sql
                cmd.Parameters.AddWithValue("dataPagamento", relatorio.DataPagamento);
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
                        RelatorioPagamentosEntity entity = new RelatorioPagamentosEntity();
                        entity.Cliente = adapter["cliente"].ToString();
                        entity.Produto = adapter["produto"].ToString();
                        entity.Preco = Convert.ToDecimal(adapter["preco"].ToString());
                        entity.Quantidade = Convert.ToInt32(adapter["quantidade"].ToString());
                        entity.Imagem = adapter["imagem"].ToString();
                        entity.Total = Convert.ToDecimal(adapter["total"].ToString());
                        entity.DataPagamento = adapter["dataPagamento"].ToString();
                        entity.TipoPagamento = adapter["tipoPagamento"].ToString();
                        entity.CodigoProduto = Convert.ToInt32(adapter["id"].ToString());
                        ListaPagamento.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaPagamento;
        }
        public List<PagamentosEntity> ListarPagamentoById(PagamentosEntity pagamento)
        {
            List<PagamentosEntity> ListaPagamento = new List<PagamentosEntity>();
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
                cmd.CommandText = "listarPagamentoById"; // Consulta Sql
                cmd.Parameters.AddWithValue("id", pagamento.Id);
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
                        PagamentosEntity entity = new PagamentosEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.IdProduto = Convert.ToInt32(adapter["idProduto"].ToString());
                        entity.IdCliente = Convert.ToInt32(adapter["idClinte"].ToString());
                        entity.Preco = Convert.ToDecimal(adapter["preco"].ToString());
                        entity.Quantidade = Convert.ToInt32(adapter["quantidade"].ToString());
                        entity.IdTipoPagamento = Convert.ToInt32(adapter["idTipoPagamento"].ToString());
                        entity.Total = Convert.ToDecimal(adapter["total"].ToString());
                        entity.DataPagamento = adapter["dataPagamento"].ToString();
                        ListaPagamento.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaPagamento;
        }
        public List<PagamentosEntity> PesquisarPagamentoByDataPagamento(PagamentosEntity pagamento)
        {
            List<PagamentosEntity> ListaPagamento = new List<PagamentosEntity>();
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
                cmd.CommandText = "listarPagamentoByData"; // Consulta Sql
                cmd.Parameters.AddWithValue("dataPagamento", pagamento.DataPagamento);
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
                        PagamentosEntity entity = new PagamentosEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.IdProduto = Convert.ToInt32(adapter["idProduto"].ToString());
                        entity.IdCliente = Convert.ToInt32(adapter["idClinte"].ToString());
                        entity.Preco = Convert.ToDecimal(adapter["preco"].ToString());
                        entity.Quantidade = Convert.ToInt32(adapter["quantidade"].ToString());
                        entity.IdTipoPagamento = Convert.ToInt32(adapter["idTipoPagamento"].ToString());
                        entity.Total = Convert.ToDecimal(adapter["total"].ToString());
                        entity.DataPagamento = adapter["dataPagamento"].ToString();
                        ListaPagamento.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaPagamento;
        }
        public string Novo(PagamentosEntity pagamento)
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
                cmd.CommandText = "novoPagamento"; // Consulta Sql

                cmd.Parameters.AddWithValue("IdProduto", pagamento.IdProduto);
                cmd.Parameters.AddWithValue("idCliente", pagamento.IdCliente);
                cmd.Parameters.AddWithValue("preco", pagamento.Preco);
                cmd.Parameters.AddWithValue("quantidade", pagamento.Quantidade);
                cmd.Parameters.AddWithValue("total", pagamento.Total);
                cmd.Parameters.AddWithValue("idTipoPagamento", pagamento.IdTipoPagamento);
                cmd.Parameters.AddWithValue("dataPagamento", pagamento.DataPagamento);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Pagamento registrado com sucesso";
                }
                else
                    resposta = "Erro: Pagamento não registrado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Editar(PagamentosEntity pagamento)
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
                cmd.CommandText = "editarPagamento"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", pagamento.Id);
                cmd.Parameters.AddWithValue("IdProduto", pagamento.IdProduto);
                cmd.Parameters.AddWithValue("idCliente", pagamento.IdCliente);
                cmd.Parameters.AddWithValue("preco", pagamento.Preco);
                cmd.Parameters.AddWithValue("quantidade", pagamento.Quantidade);
                cmd.Parameters.AddWithValue("total", pagamento.Total);
                cmd.Parameters.AddWithValue("idTipoPagamento", pagamento.IdTipoPagamento);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Pagamento atualizado com sucesso";
                }
                else
                    resposta = "Erro: Pagamento não atualizado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Eliminar(PagamentosEntity pagamento)
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
                cmd.CommandText = "eliminarPagamento"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", pagamento.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Pagamento eliminado com sucesso";
                }
                else
                    resposta = "Erro: Pagamento não eliminado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
    }
}
