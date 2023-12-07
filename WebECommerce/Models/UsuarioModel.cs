using MySql.Data.MySqlClient;
using System.Data;
using WebECommerce.Entity;
namespace WebECommerce.Models
{
    public class UsuarioModel
    {
        // Metodo de login
        private UsuarioEntity _entity = null;
        public List<UsuarioEntity> Login(UsuarioEntity user)
        {
            // Instanciando a class de conexão string
            List<UsuarioEntity> ListaUsers = new List<UsuarioEntity>();
            ConexaoModel conex = new ConexaoModel();
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
                cmd.CommandText = "loginUsuario"; // Consulta Sql
                cmd.Parameters.AddWithValue("email", user.Email);
                cmd.Parameters.AddWithValue("password", user.Password);
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
                        UsuarioEntity entity = new UsuarioEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Nome = adapter["nome"].ToString();
                        entity.Email = adapter["email"].ToString();
                        entity.IdTipo = Convert.ToInt32(adapter["idTipo"].ToString());
                        ListaUsers.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {

            }

            return ListaUsers;
        }
        public List<UsuarioEntity> ListarUsuarios()
        {
            List<UsuarioEntity> ListaUsers = new List<UsuarioEntity>();
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
                cmd.CommandText = "listarUsuario"; // Consulta Sql
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
                        UsuarioEntity entity = new UsuarioEntity();
                        entity.Id = Convert.ToInt32(adapter["id"].ToString());
                        entity.Nome = adapter["nome"].ToString();
                        entity.Email = adapter["email"].ToString();
                        entity.IdTipo = Convert.ToInt32(adapter["idTipo"].ToString());
                        ListaUsers.Add(entity);
                    }
                    adapter.Close();
                }
            }
            catch (Exception)
            {
                con = null;
                cmd = null;
            }
            return ListaUsers;
        }
        public string Novo(UsuarioEntity user)
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
                cmd.CommandText = $"update usuario set nome='{user.Nome}',email='{user.Email}',password='{user.Password}',idTipo='{user.IdTipo}' where id='{user.Id}';"; // Consulta Sql

                if (cmd.ExecuteNonQuery() == 1)
                {
                    resposta = "Usuario atualizado com sucesso";
                }
                else
                    resposta = "Erro: usuario não atualizado!";
            }
            catch (Exception)
            {

            }

            return resposta;
        }
    }

}
