using Manager.Domain.Queries.Consultas.Projetos;
using Manager.Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class ConsultaReleaseHandler : IRequestHandler<FiltrarReleasesPorProjeto, ResponseQueries>
    {
        private readonly IConsultaRelease _consultaRelease;

        public ConsultaReleaseHandler(IConsultaRelease consultaRelease)
        {
            _consultaRelease = consultaRelease;
        }

        public async Task<ResponseQueries> Handle(FiltrarReleasesPorProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Projeto não identificado", null);

            var releases = await _consultaRelease.FiltrarReleasesPorProjeto(request.ProjetoId);

            if (releases == null)
                return new ResponseQueries(false, "Nenhuma release encontrada!", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Releases do projeto " + request.ProjetoId, releases);
        }
    }
}
