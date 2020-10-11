using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class EditarProjeto : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
