using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class EditarDocumento : IRequest<Response>
    {
        public EditarDocumento(int id, string titulo, string uRL)
        {
            Id = id;
            Titulo = titulo;
            URL = uRL;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string URL { get; set; }
    }
}
