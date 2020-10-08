using MediatR;

namespace Manager.Negocio.Commands.Projetos
{
    public class CriarProjetoRequest : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
