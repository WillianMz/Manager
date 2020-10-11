using MediatR;

namespace Manager.Domain.Core.Comandos.Categorias
{
    public class EditarCategoriaRequest : IRequest<Response>
    {
        public EditarCategoriaRequest(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
