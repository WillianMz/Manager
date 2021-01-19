using MediatR;

namespace Manager.Domain.Queries.Consultas.Projetos
{
    public class FiltrarReleasesPorProjeto : IRequest<ResponseQueries>
    {
        public int ProjetoId { get; set; }
    }
}
