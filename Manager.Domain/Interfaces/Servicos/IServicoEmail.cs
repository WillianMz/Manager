namespace Manager.Domain.Interfaces.Servicos
{
    public interface IServicoEmail
    {
       void EnviarEmail(string destinatario, string titulo, string corpo);
    }
}
