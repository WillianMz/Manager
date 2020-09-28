using System.Collections.Generic;
using System.Linq;

namespace Manager.Domain.Entidades
{
    public class Projeto : EntidadeBase
    {        
        private IList<Documento> _documentos;
        private IList<Release> _releases;
        private IList<Ticket> _tickets;

        //Para o EFCore
        protected Projeto()
        {
        }

        public Projeto(string descricao)
        {
            Descricao = descricao?.Trim().ToUpper();

            _documentos = new List<Documento>();
            _releases = new List<Release>();
            _tickets = new List<Ticket>();
        }

        public int Id { get; private set; }
        public string Descricao { get; set; }

        public virtual IReadOnlyCollection<Documento> Documentos { get { return _documentos.ToArray(); } }
        public virtual IReadOnlyCollection<Release> Releases { get { return _releases.ToArray(); } }
        public virtual IReadOnlyCollection<Ticket> Tickets { get { return _tickets.ToArray(); } }


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