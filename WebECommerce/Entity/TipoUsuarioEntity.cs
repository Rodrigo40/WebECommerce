namespace WebECommerce.Entity
{
    public class TipoUsuarioEntity
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public List<TipoUsuarioEntity> ListarTipoUsuarios { get; set; }
    }
}
