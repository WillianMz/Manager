﻿using MediatR;

namespace Manager.Domain.Core.Comandos.Projetos
{
    public class ExcluirProjeto : IRequest<Response>
    {
        public int IdProjeto { get; set; }
    }
}
