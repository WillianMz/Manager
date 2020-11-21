using System.Collections.Generic;

namespace Manager.Domain.Queries.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string DataAbertura { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string StatusAtual { get; set; }
        public string Prioridade { get; set; }
        public string DataFechamento { get; set; }
        public string Tempo { get; set; }
        public string DataCancelamento { get; set; }
        public string MotivoCancelamento { get; set; }

        public string Criador { get; set; }
        public string Projeto { get; set; }
        public string Categoria { get; set; }
        public string UsuarioFechamento { get; set; }
        public string UsuarioCancelamento { get; set; }

        public List<NotaDTO> Notas { get; set; } = new List<NotaDTO>();
        public List<AnexoDTO> Anexos { get; set; } = new List<AnexoDTO>();
    }
}
