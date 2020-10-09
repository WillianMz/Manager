using MediatR;

namespace Manager.Negocio.Commands.Projetos
{
    public class EditarProjetoRequest : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
    }
}
