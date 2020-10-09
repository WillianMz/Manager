using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Negocio.Commands.Categorias
{
    public class CategoriaHandler : IRequestHandler<CategoriaRequest, Response>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public CategoriaHandler(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<Response> Handle(CategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da categoria", request);

            Categoria categoria = new Categoria(request.Nome);

            if(_repositorioCategoria.Existe(categoria))
            {
                return new Response(false, "Já existe uma categoria com o nome informado!", request);
            }

            if(categoria.Valid)
            {
                _repositorioCategoria.Adicionar(categoria);
            }
            else
            {
                return new Response(false, "Categoria é inválida", categoria.Notifications);
            }

            var result = new Response(true, "Categoria adiciona com sucesso", categoria.Nome);
            return await Task.FromResult(result);

        }
    }
}
