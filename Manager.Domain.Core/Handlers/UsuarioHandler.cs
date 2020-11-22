using Flunt.Notifications;
using Manager.Domain.Core.Comandos.Usuarios;
using Manager.Domain.Core.Eventos;
using Manager.Domain.Entidades;
using Manager.Domain.Enums;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Servicos;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class UsuarioHandler : Notifiable, IRequestHandler<RegistrarNovoUsuario, Response>,
                                              IRequestHandler<EditarUsuario, Response>,
                                              IRequestHandler<ExcluirUsuario, Response>,
                                              IRequestHandler<AlterarSenha, Response>,
                                              IRequestHandler<AtivarDestativarUsuario, Response>,
                                              IRequestHandler<AlterarTipoDeUsuario, Response>,
                                              IRequestHandler<AtivarUsuario, Response>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMediator _mediator;
        private readonly IServicoEmail _servicoEmail;

        public UsuarioHandler(IRepositorioUsuario repositorioUsuario, IMediator mediator, IServicoEmail servicoEmail)
        {
            _repositorioUsuario = repositorioUsuario;
            _mediator = mediator;
            _servicoEmail = servicoEmail;
        }

        public async Task<Response> Handle(RegistrarNovoUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do usuário", request);

            Usuario usuario = new Usuario(request.Nome, request.Login, request.Senha, request.Email);
            var emailExistente = await _repositorioUsuario.ExisteEmail(request.Email);

            if (emailExistente == true)
                return new Response(false, "Já existe algum usuário com este email", request.Email);

            if (usuario.Invalid)
                return new Response(false, "Usuário inváldo", usuario.Notifications);

            _repositorioUsuario.Adicionar(usuario);
            var codigoAtivacao = usuario.UsuarioAtivacoes.Last().CodigoAtivacao;
            EmailDeAtivacaoUsuario emailDeAtivacaoUsuario = new EmailDeAtivacaoUsuario(_servicoEmail);
            emailDeAtivacaoUsuario.EnviarEmail(usuario, codigoAtivacao);

            var result = new Response(true, "Usuário registrado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(EditarUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do usuário", request);

            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

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

            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

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

            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

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

            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", usuario);

            usuario.AtivarDesativar(request.Ativar);

            if (usuario.Invalid)
                return new Response(false, "Usuário inválido", usuario.Notifications);

            _repositorioUsuario.Editar(usuario);
            var result = new Response(true, "Usuário ativado/desativado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(AlterarTipoDeUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Identifique o usuário", request);

            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", usuario);

            switch (request.TipoUsuario)
            {
                case 1:
                    usuario.AlterarTipoDeUsuario(UsuarioEnum.Administrador);
                    break;

                case 2:
                    usuario.AlterarTipoDeUsuario(UsuarioEnum.Gerente);
                    break;

                case 3:
                    usuario.AlterarTipoDeUsuario(UsuarioEnum.MembroEquipe);
                    break;

                case 4:
                    usuario.AlterarTipoDeUsuario(UsuarioEnum.Cliente);
                    break;

                default:
                    AddNotification("Tipos de usuários", "1=Administrador | 2=Gerente | 3=Membro da equipe | 4=Cliente ");
                    break;
            }

            if(Invalid)
                return new Response(false, "Verifique os dados informados e tente novamente", Notifications);

            if (usuario.Invalid)
                return new Response(false, "Usuário inválido", usuario.Notifications);

            _repositorioUsuario.Editar(usuario);
            var result = new Response(true, "Tipo de usuário alterado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(AtivarUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Identifique o usuário", null);

            Usuario usuario = await _repositorioUsuario.ObterUsuarioPorEmail(request.Email);
            //var cod = usuario.UsuarioAtivacoes.FirstOrDefault(a => a.CodigoAtivacao == request.CodigoDeAtivacao);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", request.Email);

            usuario.Ativar(request.CodigoDeAtivacao);

            if (usuario.Invalid)
                return new Response(false, "Usuário inválido", usuario.Notifications);

            _repositorioUsuario.Editar(usuario);
            var result = new Response(true, "Usuário ativado com sucesso", null);
            return await Task.FromResult(result);
        }
    }
}
