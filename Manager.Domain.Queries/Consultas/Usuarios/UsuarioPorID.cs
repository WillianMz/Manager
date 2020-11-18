using MediatR;

namespace Manager.Domain.Queries.Consultas.Usuarios
{
    public class UsuarioPorID : IRequest<ResponseQueries>
    {
        public int Id { get; set; }
    }
}
