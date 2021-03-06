using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

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

        public Projeto(string nome, string descricao)
        {
            Nome = nome.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();

            _documentos = new List<Documento>();
            _releases = new List<Release>();
            _tickets = new List<Ticket>();
            _projetoUsuarios = new List<ProjetoUsuario>();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome,"Nome","Nome do projeto n�o pode estar vazio")
                .IsNotNullOrEmpty(Descricao,"Descri��o","Informe uma descri��o para o projeto")
            );

        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; set; }

        /* IReadOnlyCollection - Link da documenta��o da Microsoft. Estava dando erro com o EFCore
         * https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
         * 
        */
        public virtual IReadOnlyCollection<Documento> Documentos => _documentos;
        public virtual IReadOnlyCollection<Release> Releases => _releases;
        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;
        public virtual IReadOnlyCollection<ProjetoUsuario> ProjetoUsuarios => _projetoUsuarios;


        #region METODOS PUBLICOS

        public void Editar(string nome, string descricao)
        {
            Nome = nome?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome","Nome do projeto n�o pode estar vazio")
                .IsNotNullOrEmpty(Descricao,"Descri��o","Informe a descri��o do projeto")
            );
        }

        public void AdicionarMembro(Usuario usuario, bool gerente)
        {
            if (usuario.Valid)
            {             
                ProjetoUsuario projetoUsuario = new ProjetoUsuario(this, usuario, gerente);
                _projetoUsuarios.Add(projetoUsuario);
            }
            else
                AddNotification("Usuario", "Verifique o usu�rio informado");
        }

        public void AdicionarDocumento(Documento documento)
        {
            if (documento.Valid)
            {
                _documentos.Add(documento);
            }
            else
                AddNotification("Documento", "Documento informado � inv�lido");
        }

        public void AdicionarRelease(Release release)
        {
            if (release.Valid)
            {
                _releases.Add(release);
            }
            else
                AddNotification("Release", "Release informada � inv�lida");
        }

        public void ExcluirDocumento(Documento documento)
        {
            //Documento documento = _documentos.FirstOrDefault(d => d.Id == idDocumento);
            //var teste = true;
            _documentos.Remove(documento);
        }

        public void ExcluirRealease(Release release)
        {
            _releases.Remove(release);
        }

        public void ExcluirMembroDoProjeto(Usuario usuario)
        {
            ProjetoUsuario projetoUsuario = _projetoUsuarios.FirstOrDefault(p => p.Usuario == usuario);
            _projetoUsuarios.Remove(projetoUsuario);
        }

        #endregion

    }
}