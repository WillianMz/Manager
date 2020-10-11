using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Comandos.Categorias
{
    public class EditarCategoriaHandler : IRequestHandler<EditarCategoriaRequest, Response>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public EditarCategoriaHandler(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<Response> Handle(EditarCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados necessários", request);

            Categoria categoria = _repositorioCategoria.CarregarObjetoPeloID(request.Id);

            if (categoria == null)
                return new Response(false, "Nenhuma categoria encontrada", request);

            categoria.Editar(request.Nome);

            if (categoria.Invalid)
                return new Response(false, "Categoria inválida", categoria.Notifications);

            _repositorioCategoria.Editar(categoria);

            var result = new Response(true, "Categoria atualizada com sucesso!", categoria);
            return await Task.FromResult(result);
        }
    }
}
