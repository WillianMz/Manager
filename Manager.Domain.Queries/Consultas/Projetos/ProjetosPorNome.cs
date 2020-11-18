using MediatR;

namespace Manager.Domain.Queries.Consultas.Projetos
{
    public class ProjetosPorNome : IRequest<ResponseQueries>
    {
        public string Nome { get; set; }
    }
}
