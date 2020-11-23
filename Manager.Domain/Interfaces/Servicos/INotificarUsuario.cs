using Manager.Domain.Entidades;

namespace Manager.Domain.Interfaces.Servicos
{
    public interface INotificarUsuario
    {
        void EnviarCodigoDeAtivacao(Usuario usuario, string codigoAtivacao);
    }
}
