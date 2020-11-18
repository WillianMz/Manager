using MediatR;

namespace Manager.Domain.Queries.Consultas.Categorias
{
    public class CategoriaPorNome : IRequest<ResponseQueries>
    {
        public string Nome { get; set; }
    }
}
