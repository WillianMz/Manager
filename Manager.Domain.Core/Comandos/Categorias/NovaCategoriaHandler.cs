using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Comandos.Categorias
{
    public class NovaCategoriaHandler : IRequestHandler<NovaCategoriaRequest, Response>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IMediator _mediator;

        public NovaCategoriaHandler(IRepositorioCategoria repositorioCategoria, IMediator mediator)
        {
            _repositorioCategoria = repositorioCategoria;
            _mediator = mediator;
        }

        public async Task<Response> Handle(NovaCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o nome da categoria", request);

            Categoria categoria = new Categoria(request.Nome);

            if (categoria.Invalid)
                return new Response(false, "Categoria inválida! Verifique os erros.", categoria.Notifications);

            if (_repositorioCategoria.Existe(categoria))
                return new Response(false, "Já existe uma categoria com este nome!", request);

            _repositorioCategoria.Adicionar(categoria);

            var result = new Response(true, "Categoria criada com sucesso!", categoria);
            return await Task.FromResult(result);

        }
    }
}
