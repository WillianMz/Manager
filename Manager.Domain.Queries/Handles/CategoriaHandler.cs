using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Queries.Consultas.Categorias;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Queries.Handles
{
    public class CategoriaHandler : IRequestHandler<CategoriaRequest, CategoriaResponse>
    {
        private readonly IConsultaCategoria _consultaCategoria;

        public CategoriaHandler(IConsultaCategoria consultaCategoria)
        {
            _consultaCategoria = consultaCategoria;
        }

        public async Task<CategoriaResponse> Handle(CategoriaRequest request, CancellationToken cancellationToken)
        {
            

        }
    }
}
