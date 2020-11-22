using Manager.Domain.Queries.Consultas.Categorias;
using Manager.Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class ConsultaCategoriaHandler : IRequestHandler<ListarCategorias, ResponseQueries>,
                                            IRequestHandler<CategoriaPorNome, ResponseQueries>,
                                            IRequestHandler<CategoriaPorID, ResponseQueries>
    {
        private readonly IConsultaCategoria _consultaCategoria;

        public ConsultaCategoriaHandler(IConsultaCategoria consultaCategoria)
        {
            _consultaCategoria = consultaCategoria;
        }

        public async Task<ResponseQueries> Handle(ListarCategorias request, CancellationToken cancellationToken)
        {
            var categorias = _consultaCategoria.Listar();

            if (categorias == null)
                return new ResponseQueries(false, "Nenhuma categoria encontrada", null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Categorias", categorias);
        }

        public async Task<ResponseQueries> Handle(CategoriaPorNome request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe o tipo de filtro para a pesquisa", null);

            var categorias = await _consultaCategoria.ListarPorNome(request.Nome);

            if (categorias.Count == 0)
                return new ResponseQueries(false, "Nenhuma categoria encontrado com o filtro: " + request.Nome, null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Categorias", categorias);
        }

        public async Task<ResponseQueries> Handle(CategoriaPorID request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe um ID para procurar a categoria", null);

            var categoria = _consultaCategoria.ProcurarPorID(request.Id);

            if (categoria == null)
                return new ResponseQueries(false, "Nenhuma categoria encontrada com o ID: " + request.Id, null);

            return await ResponseHandlerBase.RetornoDaConsulta(true, "Categorias", categoria);
        }
    }
}
