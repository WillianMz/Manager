namespace Manager.Domain.Interfaces.Servicos
{
    public interface IServicoEnviarEmail
    {
       void EnviarEmail(string destinatario, string titulo, string corpo);
    }
}
