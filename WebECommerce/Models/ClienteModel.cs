using WebECommerce.Entity;

namespace WebECommerce.Models
{
    public class ClienteModel
    {
        public UsuarioModel Cliente { get; set; }
        public List<UsuarioEntity> ListaCliente { get; set; }
        public ClienteModel()
        {
            Cliente = new UsuarioModel();
            ListaCliente = Cliente.ListarUsuarios().Where(c => c.IdTipo == 2).ToList();
        }
    }
}
