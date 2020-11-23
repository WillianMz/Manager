using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Servicos;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class ReleaseHandler : IRequestHandler<AdicionarRelease, Response>,
                                  IRequestHandler<EditarRelease, Response>,
                                  IRequestHandler<ExcluirRelease, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioRelease _repositorioRelease;
        private readonly INotificarRelease _notificarRelease;

        public ReleaseHandler(IRepositorioProjeto repositorioProjeto, IRepositorioUsuario repositorioUsuario, 
                              IRepositorioRelease repositorioRelease, INotificarRelease notificarRelease)
        {
            _repositorioProjeto = repositorioProjeto;
            _repositorioUsuario = repositorioUsuario;
            _repositorioRelease = repositorioRelease;
            _notificarRelease = notificarRelease;
        }

        public async Task<Response> Handle(AdicionarRelease request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da release", request);

            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            Release release = new Release(request.Nome, request.Descricao, request.Versao, projeto, usuario, request.DataLiberacao);
            //projeto.AdicionarRelease(release);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", request);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", request);

            if (release.Invalid)
                return new Response(false, "Release invalida", release.Notifications);

            //_repositorioProjeto.Editar(projeto);
            _repositorioRelease.Adicionar(release);
            await _notificarRelease.Nova(usuario, projeto, release);

            var result = new Response(true, "Release adicionada com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(EditarRelease request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da release", request);
            
            Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);
            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            //Release release = projeto.Releases.FirstOrDefault(r => r.Id == request.IdRelease);
            Release release = await _repositorioRelease.CarregarObjetoPeloID(request.IdRelease);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", request);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", request);

            if (release == null)
                return new Response(false, "Release não encontrada", request);

            release.Editar(request.Nome, request.Descricao, request.Versao, usuario, request.DataLiberacao);

            //_repositorioProjeto.Editar(projeto);
            _repositorioRelease.Editar(release);

            var result = new Response(true, "Release alterada com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(ExcluirRelease request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da release", request);

            //projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            //Release release = projeto.Releases.FirstOrDefault(r => r.Id == request.idRelease);
            Release release = await _repositorioRelease.CarregarObjetoPeloID(request.IdRelease);

            if (release == null)
                return new Response(false, "Release não encontrada", request);

            //projeto.ExcluirRealease(release);
            //_repositorioProjeto.Editar(projeto);
            _repositorioRelease.Remover(release);

            var result = new Response(true, "Release excluída com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
