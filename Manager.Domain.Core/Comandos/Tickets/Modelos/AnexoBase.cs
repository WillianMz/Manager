namespace Manager.Domain.Core.Comandos.Tickets.Modelos
{
    public abstract class AnexoBase
    {
        public string Descricao { get; set; }
        public string URL { get; set; }
        public int TicketId { get; set; }
    }
}
