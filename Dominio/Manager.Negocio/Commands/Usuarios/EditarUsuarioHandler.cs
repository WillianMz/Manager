using Flunt.Notifications;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Negocio.Commands.Usuarios
{
    public class EditarUsuarioHandler : Notifiable, IRequestHandler<EditarUsuarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public EditarUsuarioHandler(IMediator mediator, IRepositorioUsuario repositorioUsuario)
        {
            _mediator = mediator;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(EditarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if(request == null)
                return new Response(false, "Informe o usuário que deseja alterar!", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.Id);

            if(usuario == null)
            {
                return new Response(false, "Usuário não encontrado", request);
            }

            if(usuario.Valid)
            {
                usuario.Editar(request.Nome);
                _repositorioUsuario.Editar(usuario);
            }
            else
            {
                return new Response(false, "Usuário inválido", usuario.Notifications);
            }

            var result = new Response(true, "Nome do usuário alterado com sucesso!", usuario.Nome);
            return await Task.FromResult(result);
        }
    }
}
