using Manager.Domain.Queries.Consultas.Projetos;
using Manager.Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class ConsultaProjetoHandler : IRequestHandler<ListarProjetos, ResponseQueries>,
                                          IRequestHandler<ProjetosPorID, ResponseQueries>,
                                          IRequestHandler<ProjetosPorNome, ResponseQueries>
    {

        private readonly IConsultaProjeto _consultaProjeto;

        public ConsultaProjetoHandler(IConsultaProjeto consultaProjeto)
        {
            _consultaProjeto = consultaProjeto;
        }

        public async Task<ResponseQueries> Handle(ListarProjetos request, CancellationToken cancellationToken)
        {
            var projetos = await _consultaProjeto.Listar();

            if (projetos.Count == 0)
                return new ResponseQueries(false, "Nenhum projeto encontrado", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Projetos", projetos);
        }

        public async Task<ResponseQueries> Handle(ProjetosPorID request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe o ID do projeto", null);

            var projeto = _consultaProjeto.ProcurarPorID(request.Id);

            if (projeto == null)
                return new ResponseQueries(false, "Nenhum projeto encontrado com o ID: " + request.Id, null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Projeto", projeto);
        }

        public async Task<ResponseQueries> Handle(ProjetosPorNome request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe um nome para pesquisar", null);

            var projetos = await _consultaProjeto.ListarPorNome(request.Nome);

            if (projetos.Count == 0)
                return new ResponseQueries(false, "Nenhum projeto encontrado", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Projetos", projetos);
        }
    }
}
