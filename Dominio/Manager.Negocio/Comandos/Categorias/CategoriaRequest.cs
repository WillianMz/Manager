using MediatR;

namespace Manager.Negocio.Comandos.Categorias
{
    public abstract class CategoriaRequest : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
