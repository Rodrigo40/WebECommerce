using MySql.Data.MySqlClient;
using System.Data;

namespace WebECommerce.Models
{
    public class ConexaoModel
    {
        private string Con = "server=localhost;database=miniecommerce;uid=root;pwd=";

        public string TestarConexaoMySql()
        {
            string resposta = string.Empty;
            //MySql.Data.MySqlClient.MySqlConnection conn = MySqlConnection();
            MySql.Data.MySqlClient.MySqlConnection con = new MySqlConnection(Con);
            try
            {
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    resposta = "Conexão aberta com sucesso!";
                }
                else
                {
                    resposta = "Erro ao abrir a conexão!";
                }
            }
            catch (Exception)
            {
                con = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Dispose();
            }

            return resposta;
        }
        public string GetConnection()
        {
            return Con;
        }
    }

}