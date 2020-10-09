namespace Manager.Negocio.Comandos.Categorias
{
    public class CriarCategoriaRequest : CategoriaRequest
    {
        public CriarCategoriaRequest(string nome)
        {
            Nome = nome;
        }
    }
}
