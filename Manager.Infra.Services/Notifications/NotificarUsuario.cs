using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Servicos;

namespace Manager.Infra.Services.Notifications
{
    public class NotificarUsuario : INotificarUsuario
    {
        private readonly IServicoEmail _servicoEmail;

        public NotificarUsuario(IServicoEmail servicoEmail)
        {
            _servicoEmail = servicoEmail;
        }

        public void EnviarCodigoDeAtivacao(Usuario usuario, string codigoAtivacao)
        {
            _servicoEmail.EnviaEmail("willianmazzorana@hotmail.com", usuario.Email,
                                    "Código de ativação de usuário",
                                    "Código para ativar o usuário: " + codigoAtivacao);
        }

    }
}
