using Flunt.Notifications;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Negocio.Commands.Projetos
{
    public class CriarProjetoHandler : Notifiable, IRequestHandler<CriarProjetoRequest, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;

        public CriarProjetoHandler(IRepositorioProjeto repositorioProjeto)
        {
            _repositorioProjeto = repositorioProjeto;
        }

        public async Task<Response> Handle(CriarProjetoRequest request, CancellationToken cancellationToken)
        {
            //verificar o request
            if (request == null)
                return new Response(false, "Informe os dados do projeto", request);

            //cria objeto
            Projeto projeto = new Projeto(request.Nome, request.Descricao);

            //verifica se o usuario é administrador

            if (_repositorioProjeto.Existe(projeto))
                return new Response(false, "Já existe um projeto com este nome", request);
            

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido!", projeto.Notifications);
            else
                _repositorioProjeto.Adicionar(projeto);

            //retorna response
            var result = new Response(true, "Projeto criado com sucesso!", projeto);
            return await Task.FromResult(result);
        }
    }
}
