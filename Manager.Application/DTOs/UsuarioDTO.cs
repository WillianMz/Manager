using System.Collections.Generic;

namespace Manager.Application.DTOs
{
    public class UsuarioDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Tipo { get; set; }

        public List<TicketDTO> Ticktes { get; set; }
        public List<NotaDTO> Notas { get; set; }
        public List<ReleaseDTO> Releases { get; set; }
        public List<ProjetoDTO> Projetos { get; set; }
    }
}
