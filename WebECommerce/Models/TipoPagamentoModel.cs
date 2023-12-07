using MySql.Data.MySqlClient;
using System.Data;
using WebECommerce.Entity;

namespace WebECommerce.Models
{
    public class TipoPagamentoModel
    {
        public List<TipoPagamentoEntity> ListarTipoPagamento()
        {
            List<TipoPagamentoEntity> ListaPagamento = new List<TipoPagamentoEntity>();
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
                cmd.CommandText = "listarTipoPagamento"; // Consulta Sql
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
                        TipoPagamentoEntity entity = new TipoPagamentoEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Tipo = adapter["tipo"].ToString();
                        entity.Descricao = adapter["descricao"].ToString();
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
        public List<TipoPagamentoEntity> ListarTipoPagamentoById(TipoPagamentoEntity tipo)
        {
            List<TipoPagamentoEntity> ListaPagamento = new List<TipoPagamentoEntity>();
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
                cmd.CommandText = "listarTipoPagamentoById"; // Consulta Sql
                cmd.Parameters.AddWithValue("id", tipo.Id);
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
                        TipoPagamentoEntity entity = new TipoPagamentoEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Tipo = adapter["tipo"].ToString();
                        entity.Descricao = adapter["descricao"].ToString();
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
        public string Novo(TipoPagamentoEntity pagamento)
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
                cmd.CommandText = "novoTipoPagamento"; // Consulta Sql

                cmd.Parameters.AddWithValue("tipo", pagamento.Tipo);
                cmd.Parameters.AddWithValue("descricao", pagamento.Descricao);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Tipo pagamento registrado com sucesso";
                }
                else
                    resposta = "Erro: Tipo pagamento não registrado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Editar(TipoPagamentoEntity pagamento)
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
                cmd.CommandText = "editarTipoPagamento"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", pagamento.Id);
                cmd.Parameters.AddWithValue("tipo", pagamento.Tipo);
                cmd.Parameters.AddWithValue("descricao", pagamento.Descricao);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Tipo pagamento atualizado com sucesso";
                }
                else
                    resposta = "Erro: Tipo pagamento não atualizado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Eliminar(TipoPagamentoEntity tipo)
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
                cmd.CommandText = "eliminarTipoPagamento"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", tipo.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Tipo pagamento eliminado com sucesso";
                }
                else
                    resposta = "Erro: Tipo pagamento não eliminado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
    }
}
