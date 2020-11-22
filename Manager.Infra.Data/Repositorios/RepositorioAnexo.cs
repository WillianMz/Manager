using Manager.Domain.Entidades;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Infra.Data.Repositorios
{
    public class RepositorioAnexo : IRepositorioAnexo
    {
        private readonly ManagerContext context;

        public RepositorioAnexo(ManagerContext managerContext)
        {
            context = managerContext;
        }

        public void Adicionar(Anexo entidade)
        {
            context.Anexos.Add(entidade);
        }

        public void AdicionarLista(IEnumerable<Anexo> entidades)
        {
            throw new NotImplementedException();
        }

        public async Task<Anexo> CarregarObjetoPeloID(int id)
        {
            Anexo anexo = context.Anexos.FirstOrDefault(a => a.Id == id);
            return await Task.FromResult(anexo);
        }

        public void Editar(Anexo entidade)
        {
            context.Anexos.Update(entidade);
        }

        public Task<bool> Existe(Anexo entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Anexo entidade)
        {
            context.Anexos.Remove(entidade);
        }

        public void RemoverLista(IEnumerable<Anexo> entidades)
        {
            throw new NotImplementedException();
        }
    }
}
