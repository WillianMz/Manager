using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Projetos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class DocumentoHandler : IRequestHandler<AdicionarDocumento, Response>,
                                    IRequestHandler<EditarDocumento, Response>,
                                    IRequestHandler<ExcluirDocumento, Response>
    {
        public Task<Response> Handle(AdicionarDocumento request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Handle(EditarDocumento request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Handle(ExcluirDocumento request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
