using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class ProjetoHandler : IRequestHandler<CriarProjeto, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;

        public ProjetoHandler(IRepositorioProjeto repositorioProjeto)
        {
            _repositorioProjeto = repositorioProjeto;
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

            var result = new Response(true, "Projeto criado com sucesso!", projeto);
            return await Task.FromResult(result);
        }
    }
}
