using Manager.Domain.Core.Comandos.Projetos.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class EquipeDoProjeto : IRequest<Response>
    {
        public int UsuarioId { get; set; }
        public bool Gerente { get; set; }
    }
}
