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
    }
}