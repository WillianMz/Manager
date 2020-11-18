using Manager.Domain.Queries.Consultas.Categorias;
using Manager.Domain.Queries.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class CategoriaConsultaHandler : IRequestHandler<ListarCategorias, ResponseQueries>,
                                            IRequestHandler<CategoriaPorNome, ResponseQueries>,
                                            IRequestHandler<CategoriaPorID, ResponseQueries>
    {
        private readonly IConsultaCategoria _consultaCategoria;

        public CategoriaConsultaHandler(IConsultaCategoria consultaCategoria)
        {
            _consultaCategoria = consultaCategoria;
        }

        private async Task<ResponseQueries> RetornoDaConsulta(bool sucesso, string mensagem, object dados)
        {
            var result = new ResponseQueries(sucesso, mensagem, dados);
            return await Task.FromResult(result);
        }

        public async Task<ResponseQueries> Handle(ListarCategorias request, CancellationToken cancellationToken)
        {
            var catg = _consultaCategoria.Listar();

            if (catg == null)
                return new ResponseQueries(false, "Nenhuma categoria encontrada", null);

            //var result = new ResponseQueries(true, "Categorias", catg);
            //return await Task.FromResult(result);
            return await RetornoDaConsulta(true, "Categorias", catg);
        }

        public async Task<ResponseQueries> Handle(CategoriaPorNome request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe o tipo de filtro para a pesquisa", null);

            var categorias = _consultaCategoria.ListarPorNome(request.Nome);

            if (categorias.Count == 0)
                return new ResponseQueries(false, "Nenhuma categoria encontrado com o filtro: " + request.Nome, null);

            //var result = new ResponseQueries(true, "Categoria", categorias);
            //return await Task.FromResult(result);
            return await RetornoDaConsulta(true, "Categorias", categorias);
        }

        public async Task<ResponseQueries> Handle(CategoriaPorID request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new ResponseQueries(false, "Informe um ID para procurar a categoria", null);

            var categoria = _consultaCategoria.ProcurarPorID(request.Id);

            if (categoria == null)
                return new ResponseQueries(false, "Nenhuma categoria encontrada com o ID: " + request.Id, null);

            //var result = new ResponseQueries(true, "Categoria", categoria);
            //return await Task.FromResult(result);
            return await RetornoDaConsulta(true, "Categorias", categoria);
        }
    }
}
