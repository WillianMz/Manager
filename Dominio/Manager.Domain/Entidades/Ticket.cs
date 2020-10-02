using Flunt.Validations;
using Manager.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Ticket : EntidadeBase
    {
        private List<Nota> _notas;

        //Para o EFCore
        protected Ticket() { }

        public Ticket(string descricao, Prioridade prioridade, Usuario usuario, Projeto projeto, Categoria categoria, Release release)
        {
            Descricao = descricao?.Trim().ToUpper();
            Prioridade = prioridade;
            Usuario = usuario;
            Projeto = projeto;
            Categoria = categoria;

            _notas = new List<Nota>();
            DataAbertura = DateTime.Now;

            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Descricao, "Descricao", "Informe a descri��o do Ticket")
                .IsNull(Prioridade, "Prioridade", "Informe a prioridade")
                .IsNull(Usuario, "Usuario", "Identifique o usu�rio criador do ticket")
                .IsNull(Projeto, "Projeto", "Informe o projeto relacionado a este ticket")
                .IsNull(Categoria, "Categoria", "Informe a categoria")
            );

        }

        public int Id { get; private set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int Tempo { get; set; }
        public string Descricao { get; set; }
        public string Solucao { get; set; }
        public string Arquivo { get; set; }

        public virtual Status Status { get; set; }
        public virtual Prioridade Prioridade { get; set; }
        
        //relacionamentos
        public int UsuarioId { get; set; }  
        public virtual Usuario Usuario { get; set; }
        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int ReleaseId { get; set; }
        public virtual Release Release { get; set; }

        public virtual IReadOnlyCollection<Nota> Notas => _notas;


        public void AdicionarNota(Nota nota)
        {
            _notas.Add(nota);
        }

        public void Editar()
        {

        }

        public void FecharTicket(string solucao)
        {
            DataFechamento = DateTime.Now;
            
            Solucao = solucao?.ToUpper();

            AddNotifications(new Contract()
                .Requires()
                .IsNullOrEmpty(Solucao, "Solucao", "Descreva a solu��o")
            );

        }
    }
}