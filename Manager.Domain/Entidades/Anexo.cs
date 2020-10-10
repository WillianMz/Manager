using Flunt.Validations;

namespace Manager.Domain.Entidades
{
    public  class Anexo : EntidadeBase
    {
        //Para o EFCore
        protected Anexo() { }

        public Anexo(string nome, string url, Ticket ticket)
        {
            Nome = nome?.Trim().ToUpper();
            URL = url?.Trim().ToLower();
            Ticket = ticket;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome do anexo")
                .IsNotNullOrEmpty(url, "URL", "Informe o caminho do arquivo em anexo")
                .IsNotNull(ticket, "Ticket", "Informe a qual ticket este anexo pertence")
            );
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string URL { get; private set; }
        public int TicketId { get; private set; }
        public virtual Ticket Ticket { get; private set; }

        public void Editar(string nome, string url)
        {
            Nome = nome?.Trim().ToUpper();
            URL = url?.Trim().ToLower();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Informe o nome do anexo")
                .IsNotNullOrEmpty(url, "URL", "Informe o caminho do arquivo em anexo")
            );
        }

    }
}
