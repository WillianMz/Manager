using Flunt.Notifications;
using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Manager.Domain.Core.Handlers
{
    public class DocumentoHandler : Notifiable, IRequestHandler<AdicionarDocumento, Response>,
                                                IRequestHandler<EditarDocumento, Response>,
                                                IRequestHandler<ExcluirDocumento, Response>
    {
        private readonly IRepositorioProjeto _repositorioProjeto;
        private readonly IRepositorioDocumento _repositorioDocumento;

        public DocumentoHandler(IRepositorioProjeto repositorioProjeto, IRepositorioDocumento repositorioDocumento)
        {
            _repositorioProjeto = repositorioProjeto;
            _repositorioDocumento = repositorioDocumento;
        }

        public async Task<Response> Handle(AdicionarDocumento request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe os dados do documento", request);

            Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            Documento documento = new Documento(request.Titulo, request.URL, projeto);

            if (projeto == null)
                return new Response(false, "Projeto não encontrado!", request);

            //projeto.AdicionarDocumento(documento);

            if (documento.Invalid)
                return new Response(false, "Documento inválido!", projeto.Notifications);

            //_repositorioProjeto.Editar(projeto);
            _repositorioDocumento.Adicionar(documento);

            var result = new Response(true, "Documento adicionado ao projeto com sucesso!", null);
            return await Task.FromResult(result);

            
        }

        public async Task<Response> Handle(EditarDocumento request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new Response(false, "Informe o projeto que deseja alterar", request);

            //Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            //Documento documento = projeto.Documentos.FirstOrDefault(d => d.Id == request.IdDocumento);
            Documento documento = await _repositorioDocumento.CarregarObjetoPeloID(request.Id);

            //if (projeto == null)
            //    return new Response(false, "Projeto não encontrado!", request);

            if (documento == null)
                return new Response(false, "Documento não encontrado", request);

            documento.Editar(request.Titulo, request.URL);

            if (documento.Invalid)
                return new Response(false, "documento inválido!", documento.Notifications);

            //_repositorioProjeto.Editar(projeto);
            _repositorioDocumento.Editar(documento);
           
            var result = new Response(true, "Documento alterado ao projeto com sucesso!", null);
            return await Task.FromResult(result);

        }

        public async Task<Response> Handle(ExcluirDocumento request, CancellationToken cancellationToken)
        {
            if(request == null)
                return new Response(false, "Informe o projeto que deseja excluir", request);

            //Projeto projeto = await _repositorioProjeto.CarregarObjetoPeloID(request.ProjetoId);
            //Documento documento = projeto.Documentos.FirstOrDefault(d => d.Id == request.IdDocumento);
            Documento documento = await _repositorioDocumento.CarregarObjetoPeloID(request.IdDocumento);

            //if (projeto == null)
            //    return new Response(false, "Projeto não encontrado", request);

            if (documento == null)
                return new Response(false, "Documento não encontrado neste projeto", request);

            //projeto.ExcluirDocumento(documento);

            //if (projeto.Invalid)
            //    return new Response(false, "Projeto inválido!", projeto.Notifications);

            //_repositorioProjeto.Editar(projeto);
            _repositorioDocumento.Remover(documento);

            var result = new Response(true, "Documento excluído com sucesso!", null);
            return await Task.FromResult(result);


        }
    }
}
