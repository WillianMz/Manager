
using MediatR;

namespace Manager.Negocio.Commands.Categorias
{
    public class CategoriaRequest : IRequest<Response>
    {
        public string Nome { get; set; }
    }
}
