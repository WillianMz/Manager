using MediatR;

namespace Manager.Domain.Core.Comandos.Usuarios
{
    public class AlterarSenha : IRequest<Response>
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
    }
}
