using MediatR;

namespace Manager.Domain.Queries.Consultas.Projetos
{
    public class ProjetosPorID : IRequest<ResponseQueries>
    {
        public int Id { get; set; }
    }
}
