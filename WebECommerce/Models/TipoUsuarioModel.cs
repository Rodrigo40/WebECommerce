using MySql.Data.MySqlClient;
using System.Data;
using WebECommerce.Entity;

namespace WebECommerce.Models
{
    public class TipoUsuarioModel
    {
        #region Padão Singleton
        private static TipoUsuarioModel instance = null;
        public TipoUsuarioModel() { }
        public static TipoUsuarioModel GetInstancia()
        {
            if (instance == null)
            {
                instance = new TipoUsuarioModel();
            }
            return instance;
        }
        #endregion
        public List<TipoUsuarioEntity> ListarTipoUsuario()
        {
            List<TipoUsuarioEntity> ListaTipo = new List<TipoUsuarioEntity>();
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
                cmd.CommandText = "listarTipoUsuario"; // Consulta Sql
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
                        TipoUsuarioEntity entity = new TipoUsuarioEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Tipo = Convert.ToInt32(adapter["tipo"].ToString());
                        entity.Descricao = adapter["descricao"].ToString();
                        ListaTipo.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaTipo;
        }
        public List<TipoUsuarioEntity> ListarTipoUsuarioById(int id)
        {
            List<TipoUsuarioEntity> ListaTipo = new List<TipoUsuarioEntity>();
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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"select * from tipousuario where id='{id}'"; // Consulta Sql
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
                        TipoUsuarioEntity entity = new TipoUsuarioEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Tipo = Convert.ToInt32(adapter["tipo"].ToString());
                        entity.Descricao = adapter["descricao"].ToString();
                        ListaTipo.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaTipo;
        }
        public string Novo(TipoUsuarioEntity tipo)
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
                cmd.CommandText = "novoTipoUsuario"; // Consulta Sql

                cmd.Parameters.AddWithValue("tipo", tipo.Tipo);
                cmd.Parameters.AddWithValue("descricao", tipo.Descricao);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Tipo de Usuario registrado com sucesso";
                }
                else
                    resposta = "Erro: Tipo usuario não registrado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Editar(TipoUsuarioEntity tipo)
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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"update tipousuario set tipo='{tipo.Tipo}',descricao='{tipo.Descricao}' where id='{tipo.Id}';"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", tipo.Id);
                cmd.Parameters.AddWithValue("tipo", tipo.Tipo);
                cmd.Parameters.AddWithValue("descricao", tipo.Descricao);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Tipo de Usuario atualizado com sucesso";
                }
                else
                    resposta = "Erro: Tipo usuario não atualizado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public string Eliminar(TipoUsuarioEntity tipo)
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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"Delete from tipousuario where id='{tipo.Id}'"; // Consulta Sql

                cmd.Parameters.AddWithValue("id", tipo.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Tipo Usuario eliminado com sucesso";
                }
                else
                    resposta = "Erro: usuario não eliminado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
    }
}
