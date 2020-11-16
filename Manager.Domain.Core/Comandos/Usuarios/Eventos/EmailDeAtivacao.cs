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
            //await _servicoEnviarEmail.EnviarEmail("willianmazzorana@hotmail.com", "willianmz.wn@gmail.com", "Manager Tickets", "Código de ativação do usuário: ");
            _servicoEnviarEmail.EnviaEmail("willianmazzorana@hotmail.com", "willianmz.wn@gmail.com", "Tickets", "Teste de envio de email");
        }
    }
}
