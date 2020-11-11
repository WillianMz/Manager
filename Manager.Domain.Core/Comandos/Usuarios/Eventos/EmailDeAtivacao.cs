using Manager.Domain.Interfaces.Servicos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Comandos.Usuarios.Eventos
{
    public class EmailDeAtivacao : INotificationHandler<NovoUsuarioNotification>
    {
        private readonly IServicoEmail _servicoEnviarEmail;

        public EmailDeAtivacao(IServicoEmail servicoEnviarEmail)
        {
            _servicoEnviarEmail = servicoEnviarEmail;
        }

        public async Task Handle(NovoUsuarioNotification notification, CancellationToken cancellationToken)
        {
            _servicoEnviarEmail.EnviarEmail(notification.Usuario.Email, "Ativação de usuário", "dfs");
        }
    }
}
