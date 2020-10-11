using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class CriarProjeto : IRequest<Response>
    {
        public CriarProjeto(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        //teste
        //public List<CriarDocumento> Documentos { get; set; }
    }
}
