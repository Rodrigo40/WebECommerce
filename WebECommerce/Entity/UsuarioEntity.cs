namespace WebECommerce.Entity
{
    public class UsuarioEntity
    {
        public int Id { get; set; } = 0;
        public int IdTipo { get; set; } = 0;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<UsuarioEntity> ListaUsuario { get; set; }

        #region Padão Singleton
        private static UsuarioEntity Instacia = null;
        public UsuarioEntity() { }
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
