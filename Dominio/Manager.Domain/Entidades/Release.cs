using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Release : EntidadeBase
    {
        //Para o EFCore
        protected Release() { }

        public Release(string nome, string descricao, string versao, Projeto projeto, Usuario usuario, DateTime dataLiberacao)
        {
            Nome = nome?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();
            Versao = versao?.ToUpper();
            Projeto = projeto;
            Usuario = usuario;

            DataDeCriacao = DateTime.Now;
            DataDeLiberacao = dataLiberacao;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome da Release")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe uma descrição para a release")
                .IsNotNullOrEmpty(versao, "Versao", "Informe a versão referente a esta release")
                .IsNotNull(projeto, "Projeto", "Informe o projeto a qual esta release pertence")
                .IsNotNull(usuario, "Usuario", "Informe o usuário responsável pela release")
            );

        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Versao { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeLiberacao { get; private set; }

        public int UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public int ProjetoId { get; private set; }
        public virtual Projeto Projeto { get; private set; }


        public void Editar(string nome, string descricao, string versao, Usuario usuario, DateTime dataLiberacao)
        {
            Nome = nome?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();
            Versao = versao?.ToUpper();
            Usuario = usuario;
            DataDeLiberacao = dataLiberacao;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome da Release")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe uma descrição para a release")
                .IsNotNullOrEmpty(versao, "Versao", "Informe a versão referente a esta release")                
                .IsNotNull(usuario, "Usuario", "Informe o usuário responsável pela release")
            );
        }
    }
}