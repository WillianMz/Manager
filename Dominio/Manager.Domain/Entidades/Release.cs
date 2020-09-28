using System.Collections.Generic;

namespace Manager.Domain.Entidades
{
    public class Release : EntidadeBase
    {
        private List<Ticket> _tickets;

        //Para o EFCore
        protected Release() { }

        public Release(string nome, string descricao, Projeto projeto)
        {
            Nome = nome?.Trim().ToUpper();
            Descricao = descricao?.Trim().ToUpper();
            Projeto = projeto;

            _tickets = new List<Ticket>();
        }


        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public int ProjetoId { get; private set; }
        public virtual Projeto Projeto { get; private set; }

        public virtual IReadOnlyCollection<Ticket> Tickets => _tickets;

    }
}