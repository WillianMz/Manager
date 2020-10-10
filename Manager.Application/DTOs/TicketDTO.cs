using System;
using System.Collections.Generic;

namespace Manager.Application.DTOs
{
    public class TicketDTO
    {
        public int Id { get; private set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string Descricao { get; set; }
        public string Solucao { get; set; }

        public string StatusAtual { get; set; }
        public string PrioridadeAtual { get; set; }

        public List<NotaDTO> Notas { get; set; }
        public List<AnexoDTO> Anexos { get; set; }
    }
}
