namespace WebECommerce.Entity
{
    public class Mensagens
    {
        public string Mensagem { get; set; }
        #region Padrão Singleton
        private static Mensagens instance=null;
        public Mensagens() { }
        public static Mensagens GetInstancia()
        {
            if(instance == null)
                instance = new Mensagens();
            return instance;
        }
        #endregion
    }
}
