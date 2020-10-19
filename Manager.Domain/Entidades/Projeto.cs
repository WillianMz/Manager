using Flunt.Validations;
using Microsoft.VisualBasic;
using System;
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
                //ProjetoUsuario user = _projetoUsuarios.FirstOrDefault(p => p.UsuarioId == usuario.Id);
                var existeUsuario = _projetoUsuarios.Any(p => p.UsuarioId == usuario.Id);

                if (existeUsuario == false)
                {
                    ProjetoUsuario projetoUsuario = new ProjetoUsuario(this, usuario, gerente);
                    _projetoUsuarios.Add(projetoUsuario);
                }
                else
                    AddNotification("Usuario", "Usu�rio com id: " + usuario.Id + ", j� faz parte deste projeto");
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

        public void EditarDocumento(int id, string titulo, string url)
        {
            Documento documento = _documentos.FirstOrDefault(d => d.Id == id);

            if (documento == null)
                AddNotification("Editar Documento", "N�o � possivel editar o documento com id: " + id + ", o mesmo n�o pertence a este projeto.");
            else
                documento.Editar(titulo, url);
        }

        public void EditarRelease(int id, string nome, string descricao, string versao, Usuario usuario, DateTime dataLiberacao)
        {
            Release release = _releases.FirstOrDefault(r => r.Id == id);

            if (release == null)
                AddNotification("Editar Release", "N�o foi possivel editar a release com id: " + id + ", a mesma n�o pertence a este projeto");
            else
                release.Editar(nome, descricao, versao, usuario, dataLiberacao);
        }

        public void ExcluirMembroDoProjeto(Usuario usuario)
        {
            ProjetoUsuario user = _projetoUsuarios.FirstOrDefault(p => p.UsuarioId == usuario.Id);

            if (user != null)
                _projetoUsuarios.Remove(user);
            else
                AddNotification("Remover Membro do Projeto", "Usu�rio com id:" + usuario.Id + " n�o pertence a este projeto");
        }

        #endregion

    }
}