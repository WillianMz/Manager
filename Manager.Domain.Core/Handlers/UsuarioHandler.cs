using Flunt.Notifications;
using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Usuarios;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class UsuarioHandler : Notifiable, IRequestHandler<RegistrarNovoUsuario, Response>,
                                              IRequestHandler<EditarUsuario, Response>,
                                              IRequestHandler<ExcluirUsuario, Response>,
                                              IRequestHandler<AlterarSenha, Response>,
                                              IRequestHandler<AtivarDestativarUsuario, Response>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public UsuarioHandler(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(RegistrarNovoUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do usuário", request);

            Usuario usuario = new Usuario(request.Nome, request.Login, request.Senha, request.Email);
            var emailExistente = _repositorioUsuario.ExisteEmail(request.Email);

            if (emailExistente == true)
                return new Response(false, "Já existe algum usuário com este email", request.Email);

            if (usuario.Invalid)
                return new Response(false, "Usuário inváldo", usuario.Notifications);

            _repositorioUsuario.Adicionar(usuario);
            var result = new Response(true, "Usuário registrado com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(EditarUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do usuário", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", usuario);

            usuario.Editar(request.Nome, request.Senha);

            if (usuario.Invalid)
                return new Response(false, "Usuário inválido", usuario.Notifications);

            _repositorioUsuario.Editar(usuario);
            var result = new Response(true, "Usuário alterado com sucesso", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(ExcluirUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Identifique o usuário", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", usuario);

            _repositorioUsuario.Remover(usuario);
            var result = new Response(true, "Usuário excluído com sucesso", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(AlterarSenha request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", usuario);

            usuario.AlterarSenha(request.SenhaAtual, request.NovaSenha);

            if (usuario.Invalid)
                return new Response(false, "Usuário inválido", usuario.Notifications);

            _repositorioUsuario.Remover(usuario);
            var result = new Response(true, "Senha alterada com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(AtivarDestativarUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Identifique o usuário", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", usuario);

            usuario.AtivarDesativar(request.Ativar);

            if (usuario.Invalid)
                return new Response(false, "Usuário inválido", usuario.Notifications);

            _repositorioUsuario.Editar(usuario);
            var result = new Response(true, "Usuário ativado/desativado com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
