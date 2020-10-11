using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class CriarDocumento : IRequest<Response>
    {
        public CriarDocumento(string titulo, string uRL, int idProjeto)
        {
            Titulo = titulo;
            URL = uRL;
            ProjetoId = idProjeto;
        }

        public string Titulo { get; set; }
        public string URL { get; set; }
        public int ProjetoId { get; set; }
    }
}
