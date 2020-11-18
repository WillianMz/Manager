using Manager.Domain.Core;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Queries.Consultas.Categorias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class CategoriaHandler : IRequestHandler<CategoriaRequest, ResponseQueries>
    {
        private readonly IConsultaCategoria _consultaCategoria;

        public CategoriaHandler(IConsultaCategoria consultaCategoria)
        {
            _consultaCategoria = consultaCategoria;
        }

        public Task<RespoopnseQueries> Handle(CategoriaRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
