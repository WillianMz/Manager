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
    public class ProjetoHandler : Notifiable , IRequestHandler<CriarProjeto, Response>,
                                               IRequestHandler<EditarProjeto, Response>,
                                               IRequestHandler<ExcluirProjeto, Response>,
                                               IRequestHandler<MembrosDoProjeto, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ProjetoHandler(IRepositorioProjeto repositorioProjeto, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioProjeto = repositorioProjeto;
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<Response> Handle(CriarProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do projeto", request);

            Projeto projeto = new Projeto(request.Nome, request.Descricao);

            //PORQUE ADICIONAR DOCUMENTOS/RELEASES/MEMBROS DA EQUIPE AO CRIAR PROJETO?
            //Pode ser que ao criar novo projeto ja tenha esses dados             
            #region ADICIONAR DOCUMENTOS
            //verificar se for igual a null. Se verificar pelo count da erro de objeto nao instanciado
            if (request.Documentos != null)
            {
                var docs = request.Documentos;

                foreach(var d in docs)
                    projeto.AdicionarDocumento(new Documento(d.Titulo, d.URL, projeto));
            }

            #endregion

            #region ADICIONAR RELEASES

            if (request.Releases != null)
            {
                var releases = request.Releases;

                foreach(var r in releases)
                {
                    var usuario = await _repositorioUsuario.CarregarObjetoPeloID(r.UsuarioId);

                    if (usuario == null)
                        return new Response(false, "Usuário não encontrado", null);
                    else
                        projeto.AdicionarRelease(new Release(r.Nome, r.Descricao, r.Versao, projeto, usuario, r.DataLiberacao));
                }
            }

            #endregion

            #region ADICIONAR MEMBROS DA EQUIPE NO PROJETO

            if(request.MembrosDoProjeto != null)
            {
                List<EquipeDoProjeto> equipe = request.MembrosDoProjeto;

                foreach(var usuarioEquipe in equipe)
                {
                    Usuario usuario = await _repositorioUsuario.CarregarObjetoPeloID(usuarioEquipe.UsuarioId);

                    if (usuario != null)
                        projeto.AdicionarMembro(usuario, usuarioEquipe.Gerente);
                    else
                        AddNotification("Usuario", "Usuario com ID: " + usuarioEquipe.UsuarioId + " não foi encontrado!");
                }
            }

            #endregion

            #region  VALIDACOES

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            var existe = await _repositorioProjeto.Existe(projeto);

            if (existe == true)
                return new Response(false, "Já existe um projeto com o mesmo nome", existe);

            _repositorioProjeto.Adicionar(projeto);

            var result = new Response(true, "Projeto criado com sucesso!", Notifications);
            return await Task.FromResult(result);

            #endregion
        }

        public async Task<Response> Handle(EditarProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do projeto que deseja alterar", request);

            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.Id);

            if (projeto == null)
                return new Response(false, "Nenhum projeto encontrado com este Id", request.Id);

            projeto.Editar(request.Nome, request.Descricao);

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Projeto atualizado com sucesso!", Notifications);
            return await Task.FromResult(result);
        }

        //Exclui o projeto e todas as suas dependencias: Documentos/Releases/Equipe
        public async Task<Response> Handle(ExcluirProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o projeto que deseja excluir", request);

            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.IdProjeto);

            if (projeto == null)
                return new Response(false, "Nenhum projeto encontrado com este id", request.IdProjeto);

            _repositorioProjeto.Remover(projeto);

            var result = new Response(true, "Projeto excluído com sucesso!", Notifications);
            return await Task.FromResult(result);
        }

        //Adicionar/Excluir membros do projeto
        public async Task<Response> Handle(MembrosDoProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o projeto e o usuário", request);

            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);            

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", null);

            #region ADICIONAR MEMBROS
          
            if (request.AdicionarMembros != null)
            {
                List<EquipeDoProjeto> equipe = request.AdicionarMembros;

                foreach (var membro in equipe)
                {
                    Usuario novoMembro = await _repositorioUsuario.CarregarObjetoPeloID(membro.UsuarioId);
                    //retorna true caso o usuario acima esteja relacionado ao projeto
                    var usuarioMembroProjeto = projeto.ProjetoUsuarios.Any(p => p.Usuario == novoMembro);

                    if(usuarioMembroProjeto == false)
                    {
                        if (novoMembro != null)
                            projeto.AdicionarMembro(novoMembro, membro.Gerente);
                        else
                            AddNotification("Usuario", "Usuário com ID: " + membro.UsuarioId + " não foi encontrado!");
                    }
                    else
                        AddNotification("Usuario", "Usuário com ID: " + membro.UsuarioId + " ja pertence a este projeto");
                }
            }

            #endregion

            #region REMOVER MEMBROS

            if (request.ExcluirMembros != null)
            {
                List<EquipeDoProjeto> equipe = request.ExcluirMembros;

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
            }

            #endregion

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Equipe do projeto alterada com sucesso!", Notifications);
            return await Task.FromResult(result);
            
        }

    }
}
