using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class CriarTicket : IRequest<Response>
    {
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int ProjetoId { get; set; }
        public int CategoriaId { get; set; }
    }
}
