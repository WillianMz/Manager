using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Manager.Domain.Entidades
{
    public class Projeto : EntidadeBase
    {        
        private List<Documento> _documentos;
        private List<Release> _releases;
        private List<Ticket> _tickets;
        private List<ProjetoUsuario> _projetoUsuarios;

        //Para o EFCore
        protected Projeto() { }

        public Projeto(string descricao)
        {
            Descricao = descricao?.Trim().ToUpper();

            _documentos = new List<Documento>();
            _releases = new List<Release>();
            _tickets = new List<Ticket>();
        }

        public int Id { get; private set; }
        public string Descricao { get; set; }

        /* IReadOnlyCollection - Link da documentação da Microsoft. Estava dando erro com o EFCore
         * https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
         * 
        */
        public virtual IReadOnlyCollection<Documento> Documentos => _documentos;
        public virtual IReadOnlyCollection<Release> Releases => _releases;
        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;
        public virtual IReadOnlyCollection<ProjetoUsuario> ProjetoUsuarios => _projetoUsuarios;


        //metodos
        public void AdicionarDocumento(Documento documento)
        {
            _documentos.Add(documento);
        }

        public void AdicionarRelease(Release release)
        {
            _releases.Add(release);
        }

        public void AdicionarUsuarioAoProjeto(Usuario usuario)
        {
            //procedimento para adicionar usuario ao projeto
        }

    }
}