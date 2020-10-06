using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioRelease : IRepositorioRelease
    {
        private readonly ManagerContext context;

        public RepositorioRelease(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Release entidade)
        {
            context.Releases.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Release> entidades)
        {
            context.Releases.AddRange(entidades);
        }

        public Release CarregarObjetoPeloID(int id)
        {
            Release release = context.Releases.FirstOrDefault(r => r.Id == id);
            return release;
        }

        public void Editar(Release entidade)
        {
            context.Releases.Update(entidade);
        }

        public bool ExisteEntidade(Release entidade)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Release> ListarNomeEmOrdemCrescente()
        {
            var releases = context.Releases.OrderBy(r => r.Nome);
            return releases;
        }

        public IQueryable<Release> ListarNomeEmOrdemDecrescente()
        {
            var releases = context.Releases.OrderByDescending(r => r.Nome);
            return releases;
        }

        public IQueryable<Release> ListarPorNome(string nome)
        {
            var releases = context.Releases.Where(r => r.Nome.Contains(nome));
            return releases;
        }

        public IList<Release> ListarTodos()
        {
            var releases = context.Releases.ToList();
            return releases;
        }

        public void Remover(Release entidade)
        {
            context.Releases.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Release> entidades)
        {
            context.Releases.RemoveRange(entidades);
        }
    }
}
