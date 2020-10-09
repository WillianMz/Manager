using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Negocio.Comandos.Categorias
{
    public class CategoriaHandler : IRequestHandler<CriarCategoriaRequest, Response>,
                                    IRequestHandler<EditarCategoriaRequest, Response>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public CategoriaHandler(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<Response> Handle(CriarCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da categoria", request);

            Categoria categoria = new Categoria(request.Nome);

            if (_repositorioCategoria.Existe(categoria))
                return new Response(false, "Já existe uma categoria com este nome. Verifique", request);

            if (categoria.Invalid)
                return new Response(false, "Categoria inválida!", categoria.Notifications);

            _repositorioCategoria.Adicionar(categoria);

            var result = new Response(true, "Categoria adicionada com sucesso", categoria);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(EditarCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da categoria que deseja alterar!", request);

            Categoria categoria = _repositorioCategoria.CarregarObjetoPeloID(request.Id);

            if(categoria == null)
                return new Response(false, "Categoria não encontrada!", categoria.Nome);

            categoria.Editar(request.Nome);

            if (categoria.Invalid)
                return new Response(false, "Categoria inválida!", categoria.Notifications);

            _repositorioCategoria.Editar(categoria);

            var result = new Response(true, "Categoria alterada com sucesso!", categoria);
            return await Task.FromResult(result);

        }
    }
}
