namespace WebECommerce.Models
{
    public class FileTools
    {
        #region Padrão Singleton
        private static FileTools Instancia = null;
        public FileTools() { }
        public static FileTools GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new FileTools();
            }
            return Instancia;
        }

        #endregion
        public void SalvarImagem(string caminho, IFormFile foto)
        {
            FileStream fl = new FileStream(caminho, FileMode.Create, FileAccess.Write);
            foto.CopyToAsync(fl);
        }
    }
}