using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Negocio.Commands.Projetos
{
    public class EditarProjetoHandler : IRequestHandler<EditarProjetoRequest, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;

        public EditarProjetoHandler(IRepositorioProjeto repositorioProjeto)
        {
            _repositorioProjeto = repositorioProjeto;
        }

        public async Task<Response> Handle(EditarProjetoRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Identifique o projeto que deseja alterar", request);

            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.Id);

            //documentos
            //releases
            //usuarios

            var x = new Response(false, "Identifique o projeto que deseja alterar", request);
            return await Task.FromResult(x);
        }
    }
}
