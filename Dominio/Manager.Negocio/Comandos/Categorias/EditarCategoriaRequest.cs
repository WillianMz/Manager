namespace Manager.Negocio.Comandos.Categorias
{
    public class EditarCategoriaRequest : CategoriaRequest
    {
        public EditarCategoriaRequest(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
