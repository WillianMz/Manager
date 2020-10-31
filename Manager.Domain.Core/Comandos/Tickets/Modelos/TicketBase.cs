namespace Manager.Domain.Core.Comandos.Tickets.Modelos
{
    public abstract class TicketBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }        
        public int CriadorId { get; set; }
        public int ProjetoId { get; set; }
        public int CategoriaId { get; set; }

    }
}
