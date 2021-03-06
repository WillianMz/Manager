﻿using Manager.Domain.Core.Comandos.Tickets.Modelos;
using MediatR;

namespace Manager.Domain.Core.Comandos.Tickets
{
    public class EditarNota : NotaBase, IRequest<Response>
    {
        public int IdNota { get; set; }
    }
}
