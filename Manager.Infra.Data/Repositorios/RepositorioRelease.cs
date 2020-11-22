using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public async Task<Release> CarregarObjetoPeloID(int id)
        {
            Release release = context.Releases.FirstOrDefault(r => r.Id == id);
            return await Task.FromResult(release);
        }

        public void Editar(Release entidade)
        {
            context.Releases.Update(entidade);
        }

        public Task<bool> Existe(Release entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Release entidade)
        {
            context.Releases.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Release> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
