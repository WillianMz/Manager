using System.Collections.Generic;

namespace Manager.Application.DTOs
{
    public class ProjetoDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<DocumentoDTO> Documento { get; set; }
        public List<ReleaseDTO> Releases { get; set; }
        public List<TicketDTO> Tickets { get; set; }
        public List<UsuarioDTO> Usuarios { get; set; }
    }
}
