using MediatR;

namespace Manager.Domain.Queries.Consultas.Categorias
{
    public class CategoriaResponse : IRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
