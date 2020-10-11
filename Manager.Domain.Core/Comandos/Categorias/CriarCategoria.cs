using MediatR;

namespace Manager.Domain.Core.Comandos.Categorias
{
    public class CriarCategoria : IRequest<Response>
    {
        public CriarCategoria(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
