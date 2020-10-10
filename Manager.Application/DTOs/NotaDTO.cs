using System;

namespace Manager.Application.DTOs
{
    public class NotaDTO
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDaNota { get; set; }
        public TicketDTO Ticket { get;  set; }

        public UsuarioDTO Usuario { get; private set; }
    }
}
