using MediatR;

namespace Manager.Domain.Queries.Consultas.Categorias
{
    public class CategoriaRequest : IRequest<CategoriaResponse>
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
    }
}
