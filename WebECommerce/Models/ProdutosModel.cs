using MySql.Data.MySqlClient;
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
            if (Instancia == null)
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
                        entity.Imagem = adapter["imagem"].ToString();
                        entity.DataCadastro = adapter["dataCadastro"].ToString();
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
        public List<RelatorioPagamentosEntity> ListarProdutosPagosClienteById(int id)
        {
            List<RelatorioPagamentosEntity> ListaProdutos = new List<RelatorioPagamentosEntity>();
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
                cmd.CommandText = $"SELECT u.nome as cliente,pt.nome as produto,pt.preco,pt.quantidade,pt.imagem, p.total,p.dataPagamento,tp.tipo as tipoPagamento,pt.id FROM pagamentos p INNER JOIN produto pt on p.idProduto=pt.id INNER JOIN usuario u on p.idClinte=u.id INNER JOIN tipopagamento tp on p.idTipoPagamento=tp.id where u.id='{id}';"; // Consulta Sql
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
        public List<ProdutosEntity> PesquisarProdutos(ProdutosEntity produto)
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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"select * from produto where nome like '{produto.Nome}%'"; // Consulta Sql
                 // Consulta Sql
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
                        entity.Imagem = adapter["imagem"].ToString();
                        entity.DataCadastro = adapter["dataCadastro"].ToString();
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
        public List<ProdutosEntity> ListarProdutosById(int id)
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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"SELECT * FROM produto where id='{id}';"; // Consulta Sql
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
                        entity.Imagem = adapter["imagem"].ToString();
                        entity.DataCadastro = adapter["dataCadastro"].ToString();
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
        public List<ProdutosEntity> ListarProdutosClienteById(int id)
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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"SELECT * FROM produto where id='{id}';"; // Consulta Sql
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
                        entity.Imagem = adapter["imagem"].ToString();
                        entity.DataCadastro = adapter["dataCadastro"].ToString();
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
                cmd.Parameters.AddWithValue("dataCadastro", produto.DataCadastro);

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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"UPDATE produto set nome='{produto.Nome}',preco='{produto.Preco}',quantidade='{produto.Quantidade}',desconto='{produto.Desconto}',imagem='{produto.Imagem}' where id='{produto.Id}';"; // Consulta Sql

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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"delete from produto where id='{produto.Id}';"; // Consulta Sql

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
        public string VerificarSeJaFoiVendido(int Idproduto)
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
                cmd.CommandText = $"SELECT * from pagamentos p INNER JOIN produto pt on pt.id=p.idProduto where pt.id={Idproduto}"; // Consulta Sql

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    resposta = "Não é possivél eliminar um produto que já foi vendido!";
                }
                else
                {
                    resposta = "ok";
                }
            }
            catch (Exception)
            {

            }

            return resposta;
        }
        public static List<RelatorioPagamentosEntity> ListarPagamentosByIdCliente(int id)
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
                cmd.CommandType = CommandType.Text;
                //Definindo o comando de consulta sql
                cmd.CommandText = $"SELECT u.nome as cliente,pt.nome as produto,pt.preco,pt.quantidade,pt.imagem, p.total,p.dataPagamento,tp.tipo as tipoPagamento,pt.id FROM pagamentos p INNER JOIN produto pt on p.idProduto=pt.id INNER JOIN usuario u on p.idClinte=u.id INNER JOIN tipopagamento tp on p.idTipoPagamento=tp.id where u.id='{id}';"; // Consulta Sql
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
    }
}
