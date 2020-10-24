using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System;
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

        public ReleaseHandler(IRepositorioProjeto repositorioProjeto, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioProjeto = repositorioProjeto;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(AdicionarRelease request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da release", request);

            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if(usuario == null)
                return new Response(false, "Usuário não encontrado", request);

            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", request);

            Release release = new Release(request.Nome, request.Descricao, request.Versao, projeto, usuario, request.DataLiberacao);
            projeto.AdicionarRelease(release);

            if (projeto.Invalid)
                return new Response(false, "Projeto invalido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Release adicionada com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(EditarRelease request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da release", request);
            
            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", request);

            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            Release release = projeto.Releases.FirstOrDefault(r => r.Id == request.IdRelease);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", request);

            if (release == null)
                return new Response(false, "Release não encontrada", request);

            release.Editar(request.Nome, request.Descricao, request.Versao, usuario, request.DataLiberacao);

            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Release adicionada com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(ExcluirRelease request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados da release", request);

            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            Release release = projeto.Releases.FirstOrDefault(r => r.Id == request.idRelease);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", request);

            projeto.ExcluirRealease(release);
            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Release adicionada com sucesso!", null);
            return await Task.FromResult(result);
        }
    }
}
