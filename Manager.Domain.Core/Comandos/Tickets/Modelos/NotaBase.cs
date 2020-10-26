namespace Manager.Domain.Core.Comandos.Tickets.Modelos
{
    public abstract class NotaBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
    }
}
