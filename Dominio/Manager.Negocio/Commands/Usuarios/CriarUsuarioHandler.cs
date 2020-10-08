using Flunt.Notifications;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Negocio.Commands.Usuarios
{
    public class CriarUsuarioHandler : Notifiable, IRequestHandler<CriarUsuarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CriarUsuarioHandler(IMediator mediator, IRepositorioUsuario repositorioUsuario)
        {
            _mediator = mediator;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(CriarUsuarioRequest request, CancellationToken cancellationToken)
        {
            //verifica se o request veio preenchido
            if(request == null)
            {                
                return new Response(false, "Não foi informado nenhum dado do usuário", request);
            }

            //verificar se o usuário já existe
            if (_repositorioUsuario.ExisteEmail(request.Email))
            {
                return new Response(false, "Já existe um usuário com este email!", request);
            }

            //cria Usuario
            Usuario usuario = new Usuario(request.Nome, request.Login, request.Senha, request.Email);

            if (usuario.Invalid)
                return new Response(false, "Usuário inválido!", usuario.Notifications);
            else
                _repositorioUsuario.Adicionar(usuario);

            //cria notificacao toda vez que for criado um novo usuário
            //cria notificação para ser usada em outras partes do sistema
            CriarUsuarioNotification adicionarNotificacao = new CriarUsuarioNotification(usuario);
            await _mediator.Publish(adicionarNotificacao);

            //retorna response
            var response = new Response(true, "Usuário criado com sucesso!", usuario);

            return await Task.FromResult(response);

        }
    }
}
