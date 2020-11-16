using System.Threading.Tasks;

namespace Manager.Domain.Interfaces.Servicos
{
    public interface IServicoEmail
    {
        void EnviaEmail(string remetente, string destinatario, string titulo, string corpo);
    }
}
