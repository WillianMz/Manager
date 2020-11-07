using Flunt.Notifications;
using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Usuarios;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Utilitario;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class AutenticarUsuarioHandler : Notifiable, IRequestHandler<FazerLogin, Response>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public AutenticarUsuarioHandler(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(FazerLogin request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Identifique-se", null);

            var login = _repositorioUsuario.ExisteEmail(request.Email);

            if (login == false)
                return new Response(false, "Usuário não encontrado", null);
            
            Usuario usuario = _repositorioUsuario.ExisteUsuario(request.Email, request.Senha.CriptografarSenha());

            if (usuario == null)
                return new Response(false, "Usuário ou senha inválidos", null);            

            //gravar logs de login

            var result = new Response(true, "OK", usuario.Nome);
            return await Task.FromResult(result);
        }
    }
}
