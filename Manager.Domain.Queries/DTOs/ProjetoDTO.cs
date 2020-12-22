using System.Collections.Generic;

namespace Manager.Domain.Queries.DTOs
{
    public class ProjetoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<DocumentoDTO> Documentos { get; set; } = new List<DocumentoDTO>();
        public List<ReleaseDTO> Releases { get; set; } = new List<ReleaseDTO>();
        public List<ProjetoUsuarioDTO> Equipe { get; set; } = new List<ProjetoUsuarioDTO>();
    }
}
