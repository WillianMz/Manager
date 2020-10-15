using Manager.Domain.Core.Comandos;
using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class ProjetoHandler : IRequestHandler<CriarProjeto, Response>,
                                  IRequestHandler<EditarProjeto, Response>,
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

            #region ADICIONAR DOCUMENTOS
            //verificar se for igual a null. Se verificar pelo count da erro de objeto nao instanciado
            if (request.Documentos != null)
            {
                var docs = request.Documentos;

                foreach(var d in docs)
                {
                    projeto.AdicionarDocumento(new Documento(d.Titulo, d.URL, projeto));
                }
            }

            #endregion

            #region ADICIONAR RELEASES

            if (request.Releases != null)
            {
                var releases = request.Releases;

                foreach(var r in releases)
                {
                    var usuario = _repositorioUsuario.CarregarObjetoPeloID(r.UsuarioId);

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
                var equipe = request.MembrosDoProjeto;

                foreach(var usuarioEquipe in equipe)
                {
                    Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(usuarioEquipe.UsuarioId);

                    if (usuario == null)
                    {
                        //adicionar a uma lista de notificacao, pois pode ser que apenas um usuario não exista
                        //mas os demais sim
                    }
                    else
                        projeto.AdicionarMembro(usuario, usuarioEquipe.Gerente);
                }
            }
            #endregion


            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            var existe = _repositorioProjeto.Existe(projeto);

            if (existe == true)
                return new Response(false, "Já existe um projeto com o mesmo nome", existe);

            _repositorioProjeto.Adicionar(projeto);

            var result = new Response(true, "Projeto criado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(EditarProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do projeto que deseja alterar", request);

            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.IdProjeto);

            #region EDITAR DOCUMENTOS
            if (request.Documentos != null)
            {
                //var docs = request.Documentos;

                //foreach (var d in docs)
                //{
                //    var x = projeto.Documentos.
                //}
            }
            #endregion

            #region EDITAR RELEASES

            #endregion

            #region EDITAR MEMBROS DO PROJETO

            #endregion

            if (projeto == null)
                return new Response(false, "Nenhum projeto encontrado com este Id", request.IdProjeto);

            projeto.Editar(request.Nome, request.Descricao);

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Projeto atualizado com sucesso!", null);
            return await Task.FromResult(result);
        }

        public async Task<Response> Handle(MembrosDoProjeto request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o projeto e o usuário", request);

            Projeto projeto = _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            Usuario usuario = _repositorioUsuario.CarregarObjetoPeloID(request.UsuarioId);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado", null);

            if (usuario == null)
                return new Response(false, "Usuário não encontrado", null);

            //verificar se o usuario ja pertence ao projeto

            projeto.AdicionarMembro(usuario, request.Gerente);

            if (projeto.Invalid)
                return new Response(false, "Projeto inválido", projeto.Notifications);

            _repositorioProjeto.Editar(projeto);

            var result = new Response(true, "Usuário adicionado com sucesso", null);
            return await Task.FromResult(result);
            
        }
    }
}
