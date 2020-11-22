using Manager.Domain.Core.Comandos.Categorias;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class CategoriaHandler : IRequestHandler<CriarCategoria, Response>,
                                    IRequestHandler<EditarCategoria, Response>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public CategoriaHandler(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<Response> Handle(CriarCategoria request, CancellationToken cancellationToken)
        {
            if(request == null)
                return new Response(false, "Informe o nome da categoria", request);

            Categoria categoria = new Categoria(request.Nome);

            if (categoria.Invalid)
                return new Response(false, "Categoria inválida! Verifique os erros.", categoria.Notifications);

            if (await _repositorioCategoria.Existe(categoria))
                return new Response(false, "Já existe uma categoria com este nome!", request);

            _repositorioCategoria.Adicionar(categoria);

            var result = new Response(true, "Categoria criada com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(EditarCategoria request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados necessários", request);

            Categoria categoria = await _repositorioCategoria.CarregarObjetoPeloID(request.Id);

            if (categoria == null)
                return new Response(false, "Nenhuma categoria encontrada", request);

            categoria.Editar(request.Nome);

            if (categoria.Invalid)
                return new Response(false, "Categoria inválida", categoria.Notifications);

            _repositorioCategoria.Editar(categoria);

            var result = new Response(true, "Categoria atualizada com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
