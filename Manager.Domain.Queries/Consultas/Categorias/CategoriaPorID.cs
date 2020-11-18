using MediatR;

namespace Manager.Domain.Queries.Consultas.Categorias
{
    public class CategoriaPorID : IRequest<ResponseQueries>
    {
        public int Id { get; set; }
    }
}
