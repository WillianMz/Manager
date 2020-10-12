using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class ProjetoHandler : IRequestHandler<CriarProjeto, Response>,
                                  IRequestHandler<EditarProjeto, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IMediator _mediator;

        public ProjetoHandler(IRepositorioProjeto repositorioProjeto, IMediator mediator)
        {
            _repositorioProjeto = repositorioProjeto;
            _mediator = mediator;
        }

        public async Task<Response> Handle(CriarProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do projeto", request);

            Projeto projeto = new Projeto(request.Nome, request.Descricao);

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            var existe = _repositorioProjeto.Existe(projeto);

            if (existe == true)
                return new Response(false, "Já existe um projeto com o mesmo nome", existe);

            _repositorioProjeto.Adicionar(projeto);

            var result = new Response(true, "Projeto criado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(EditarProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do projeto que deseja alterar", request);

            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.Id);

            if (projeto == null)
                return new Response(false, "Nenhum projeto encontrado com este Id", request.Id);

            projeto.Editar(request.Nome, request.Descricao);

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Projeto atualizado com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
