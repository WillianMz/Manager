using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Servicos;

namespace Manager.Domain.Core.Eventos
{
    public class EmailDeAtivacaoUsuario
    {
        private readonly IServicoEmail _servicoEmail;

        public EmailDeAtivacaoUsuario(IServicoEmail servicoEmail)
        {
            _servicoEmail = servicoEmail;
        }

        public void EnviarEmail(Usuario usuario, string codigoAtivacao)
        {
            _servicoEmail.EnviaEmail("willianmazzorana@hotmail.com", usuario.Email, 
                                    "Novo usuário", 
                                    "Código para ativar o usuário: "+codigoAtivacao);
        }
    }
}
