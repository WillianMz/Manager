using MediatR;

namespace Manager.Domain.Core.Comandos.Categorias
{
    public class EditarCategoria : IRequest<Response>
    {
        public EditarCategoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
