using Flunt.Notifications;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
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
            throw new NotImplementedException();
        }
    }
}
