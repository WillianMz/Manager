﻿using System;

namespace Manager.Domain.Core.Comandos.Projetos.Modelos
{
    public abstract class ReleaseBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Versao { get; set; }
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataLiberacao { get; set; }
    }
}
