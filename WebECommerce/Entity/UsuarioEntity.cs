namespace WebECommerce.Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UsuarioEntity> ListaUsuario { get; set; }
       
        #region Padão Singleton
        private static UsuarioEntity Instacia = null;
        public UsuarioEntity(){}
        public static UsuarioEntity GetInstancia()
        {
            if (Instacia == null)
            {
                Instacia = new UsuarioEntity();
            }
            return Instacia;
        }
        #endregion
    }
}
