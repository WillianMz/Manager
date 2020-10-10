namespace Manager.Application.DTOs
{
    public class AnexoDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public TicketDTO Ticket { get; set; }
    }
}
