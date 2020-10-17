using System.Collections.Generic;

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

            if (string.IsNullOrEmpty(nome))
                AddNotification("Nome", "Nome do projeto não pode estar vazio");

            if (string.IsNullOrEmpty(descricao))
                AddNotification("Descricao", "Informe uma descrição para o projeto");

        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; set; }

        /* IReadOnlyCollection - Link da documentação da Microsoft. Estava dando erro com o EFCore
         * https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
         * 
        */
        public virtual IReadOnlyCollection<Documento> Documentos => _documentos;
        public virtual IReadOnlyCollection<Release> Releases => _releases;
        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;
        public virtual IReadOnlyCollection<ProjetoUsuario> ProjetoUsuarios => _projetoUsuarios;


        //METODOS
        public void Editar(string nome, string descricao)
        {
            Nome = nome?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();
           
            if (string.IsNullOrEmpty(nome))
                AddNotification("Nome", "Nome do projeto não pode estar vazio");

            if (string.IsNullOrEmpty(descricao))
                AddNotification("Descricao", "Informe uma descrição para o projeto");
        }

        public void AdicionarMembro(Usuario usuario, bool gerente)
        {
            if (usuario.Valid)
            {                
                ProjetoUsuario projetoUsuario = new ProjetoUsuario(this, usuario, gerente);
                _projetoUsuarios.Add(projetoUsuario);
            }
            else
            {
                AddNotification("Usuario", "Usuário informado é inválido");
            }
                
        }

        public void AdicionarDocumento(Documento documento)
        {
            if (documento.Valid)
            {
                _documentos.Add(documento);
            }
            else
                AddNotification("Documento", "Documento informado é inválido");
        }

        public void AdicionarRelease(Release release)
        {
            if (release.Valid)
            {
                _releases.Add(release);
            }
            else
                AddNotification("Release", "Release informada é inválida");
        }

        //public void EditarDocumento(Documento documento)
        //{
        //    Documento documento1 = documento;
        //    documento1.Editar(documento);
        //}

        //public void EditarRelease(Release release)
        //{

        //}

    }
}