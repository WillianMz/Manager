using MediatR;

namespace Manager.Domain.Queries.Consultas.Usuarios
{
    public class UsuarioPorNome : IRequest<ResponseQueries>
    {
        public string Nome { get; set; }
    }
}
