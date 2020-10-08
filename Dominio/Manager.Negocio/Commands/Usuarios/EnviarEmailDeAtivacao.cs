using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Negocio.Commands.Usuarios
{
    public class EnviarEmailDeAtivacao : INotificationHandler<CriarUsuarioNotification>
    {
        public async Task Handle(CriarUsuarioNotification notification, CancellationToken cancellationToken)
        {
            //Criar rotina para enviar email ao usuario para ativa-lo
            Debug.WriteLine("Implementar envio de email para ativar o usuário. " + notification.Usuario.Email);
        }
    }
}
