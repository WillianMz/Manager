using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Projetos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class ReleaseHandler : IRequestHandler<AdicionarRelease, Response>
    {
        public Task<Response> Handle(AdicionarRelease request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
