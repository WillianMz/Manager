using System;

namespace Manager.Application.DTOs
{
    public class ReleaseDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Versao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeLiberacao { get; set; }

        public UsuarioDTO Usuario { get; set; }
        public ProjetoDTO Projeto { get; set; }
    }
}
