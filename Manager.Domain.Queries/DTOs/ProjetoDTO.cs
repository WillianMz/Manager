using System.Collections.Generic;

namespace Manager.Domain.Queries.DTOs
{
    public class ProjetoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public List<DocumentoDTO> Documentos { get; set; }
        public List<ReleaseDTO> Releases { get; set; }
    }
}
