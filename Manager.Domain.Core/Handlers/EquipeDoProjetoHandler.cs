using Flunt.Notifications;
using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class EquipeDoProjetoHandler : Notifiable, IRequestHandler<AdicionarMembroNaEquipe, Response>,
                                                      IRequestHandler<RemoverMembroDaEquipe, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public EquipeDoProjetoHandler(IRepositorioProjeto repositorioProjeto, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioProjeto = repositorioProjeto;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(AdicionarMembroNaEquipe request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Nenhum membro da equipe foi informado", null);

            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", null);

            List<EquipeDoProjeto> equipe = request.MembrosDaEquipe;
            foreach (var membro in equipe)
            {
                Usuario novoMembro = await _repositorioUsuario.CarregarObjetoPeloID(membro.UsuarioId);
                var usuarioMembroDoProjeto = projeto.ProjetoUsuarios.Any(p => p.Usuario == novoMembro);

                if (usuarioMembroDoProjeto == false)
                {
                    if (novoMembro != null)
                        projeto.AdicionarMembro(novoMembro, membro.Gerente);
                    else
                        AddNotification("Usuario", "Usuário com o ID: " + membro.UsuarioId + " não foi encontrado");
                }
                else
                    AddNotification("Usuario", "Usuário com ID: " + membro.UsuarioId + " já pertence a este projeto");
            }

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);
            var result = new Response(true, "Equipe do projeto atualizada com sucesso", Notifications);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(RemoverMembroDaEquipe request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Nenhum membro da equipe foi informado", null);

            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", null);

            List<EquipeDoProjeto> equipe = request.MembrosDaEquipe;
            foreach (var membro in equipe)
            {
                Usuario membroParaExcluir = await _repositorioUsuario.CarregarObjetoPeloID(membro.UsuarioId);
                var usuarioMembroProjeto = projeto.ProjetoUsuarios.Any(p => p.Usuario == membroParaExcluir);

                if (usuarioMembroProjeto == true)
                {
                    if (membroParaExcluir != null)
                        projeto.ExcluirMembroDoProjeto(membroParaExcluir);
                    else
                        AddNotification("Usuario", "Usuário com ID: " + membro.UsuarioId + " não foi encontrado!");
                }
                else
                    AddNotification("Usuario", "Usuário com ID: " + membro.UsuarioId + " não pertence a este projeto");
            }

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);
            var result = new Response(true, "Equipe do projeto atualizada com sucesso", Notifications);
            return await Task.FromResult(result);
        }
    }
}
