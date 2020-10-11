using MediatR;

namespace Manager.Domain.Core.Comandos.Categorias
{
    public class NovaCategoriaRequest : IRequest<Response>
    {
        public NovaCategoriaRequest(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
