using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioDocumento : IRepositorioDocumento
    {
        private readonly ManagerContext context;

        public RepositorioDocumento(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Documento entidade)
        {
            context.Documentos.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Documento> entidades)
        {
            context.Documentos.AddRange(entidades);
        }

        public Documento CarregarObjetoPeloID(int id)
        {
            Documento documento = context.Documentos.FirstOrDefault(d => d.Id == id);
            return documento;
        }

        public void Editar(Documento entidade)
        {
            context.Documentos.Update(entidade);
        }

        public bool ExisteEntidade(Documento entidade)
        {
            //teste
            var doc = context.Documentos.Where(d => d.Projeto == entidade.Projeto).Any(d => d.Titulo == entidade.Titulo);
            return doc;
        }

        public IQueryable<Documento> ListarNomeEmOrdemCrescente()
        {
            var docs = context.Documentos.OrderBy(d => d.Titulo);
            return docs;
        }

        public IQueryable<Documento> ListarNomeEmOrdemDecrescente()
        {
            var docs = context.Documentos.OrderByDescending(d => d.Titulo);
            return docs;
        }

        public IQueryable<Documento> ListarPorNome(string nome)
        {
            var documento = context.Documentos.Where(d => d.Titulo.Contains(nome));
            return documento;
        }

        public IList<Documento> ListarTodos()
        {
            var documento = context.Documentos.ToList();
            return documento;
        }

        public void Remover(Documento entidade)
        {
            context.Documentos.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Documento> entidades)
        {
            context.Documentos.RemoveRange(entidades);
        }
    }
}
